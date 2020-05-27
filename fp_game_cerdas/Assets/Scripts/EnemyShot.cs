using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShot : MonoBehaviour
{
    public int m_PlayerNumber = 1;              // Used to identify the different players.
    public Rigidbody m_Shell;                   // Prefab of the shell.
    private Transform m_FireTransform;           // A child of the tank where the shells are spawned.
    public Transform m_FireTransformright;           // A child of the tank where the shells are spawned.
    public Transform m_FireTransformleft;           // A child of the tank where the shells are spawned.
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
    public AudioClip m_ChargingClip;            // Audio that plays when each shot is charging up.
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.
    public float m_MinLaunchForce = 30f;        // The force given to the shell if the fire button is not held.
    public float m_MaxLaunchForce = 50f;        // The force given to the shell if the fire button is held for the max charge time.
    public float m_MaxChargeTime = 0.75f;       // How long the shell can charge for before it is fired at max force.
    public float shootDelay;
    public float shootAngle = 50f;

    private GameObject goPlayer;

    private float timer;

    private string m_FireButton;                // The input axis that is used for launching shells.
    private string m_AltFireButton;                // The input axis that is used for launching shells.
    private float m_CurrentLaunchForce;         // The force that will be given to the shell when the fire button is released.
    private float m_ChargeSpeed;                // How fast the launch force increases, based on the max charge time.
    // private bool m_Fired;                       // Whether or not the shell has been launched with this button press.
    private float m_nextShoot = 0f;

    // public bool useInvoke;
    public bool running;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_FireTransform = m_FireTransformright;

        timer = shootDelay;

        goPlayer = GameObject.FindWithTag("Player");

        // if (useInvoke)
        //      InvokeRepeating("TestCoroutine", 0, Random.Range(1, 5));
        // else
        //      StartCoroutine(TestCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3ToPlayer = goPlayer.transform.position - transform.position;

        if (Vector3.Angle(v3ToPlayer, transform.right) < shootAngle) {
            // Do the right side facing stuff
            m_FireTransform = m_FireTransformright;
        }  
        else if (Vector3.Angle(v3ToPlayer, -transform.right) < shootAngle) {
            // Do the left side facing stuff
            m_FireTransform = m_FireTransformleft;
        }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Fire();
            timer = shootDelay;
        }
        
    }

    IEnumerator TestCoroutine()
     {
         running = true;
         yield return new WaitForSeconds(5);
         while (running)
         {
             yield return new WaitForSeconds(3);
             Fire();
         }
     }


    private void Fire ()
    {

        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance =
            Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; ;

        // Change the clip to the firing clip and play it.
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play ();

        // Reset the launch force.  This is a precaution in case of missing button events.
        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}