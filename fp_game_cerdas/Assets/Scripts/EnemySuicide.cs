using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuicide : MonoBehaviour
{
    // public float m_ExplosionForce = 1000f;              // The amount of force added to a Ship at the centre of the explosion.
    // public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion Ships can be and are still affected.
    public float damage = 50f;
    public GameObject m_ExplosionPrefab;                // A prefab that will be instantiated in Awake, then used whenever the Ship dies.


    private AudioSource m_ExplosionAudio;               // The audio source to play when the Ship explodes.
    private ParticleSystem m_ExplosionParticles;        // The particle system the will play when the Ship is destroyed.


    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate the explosion prefab and get a reference to the particle system on it.
        m_ExplosionParticles = Instantiate (m_ExplosionPrefab).GetComponent<ParticleSystem> ();

        // Get a reference to the audio source on the instantiated prefab.
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource> ();

        // Disable the prefab so it can be activated when it's required.
        m_ExplosionParticles.gameObject.SetActive (false);
        
        target = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag.Equals ("Player")) {

            // Find the ShipHealth script associated with the rigidbody.
            ShipHealth targetHealth = target.GetComponent<ShipHealth> ();

            // Calculate the amount of damage the target should take based on it's distance from the shell.

            // Move the instantiated explosion prefab to the Ship's position and turn it on.
            m_ExplosionParticles.transform.position = transform.position;
            m_ExplosionParticles.gameObject.SetActive (true);

            // Play the particle system of the Ship exploding.
            m_ExplosionParticles.Play ();

            // Play the Ship explosion sound effect.
            m_ExplosionAudio.Play();

            // Deal this damage to the Ship.
            targetHealth.TakeDamage (damage);

            // Destroy(gameObject);
            gameObject.SetActive (false);

        }
    }
}
