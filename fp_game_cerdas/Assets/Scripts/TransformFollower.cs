 using UnityEngine;
 using System.Collections;
 
 public class TransformFollower : MonoBehaviour
 {
     [SerializeField]
     private Transform target;
 
     [SerializeField]
     private Vector3 offsetPosition;
 
     [SerializeField]
     private Space offsetPositionSpace = Space.Self;
 
     [SerializeField]
     private bool lookAt = true;

     private void Update()
     {
         Refresh();
     }
 
     public void Refresh()
     {
         if(target == null)
         {
             Debug.LogWarning("Missing target ref !", this);
 
             return;
         }

         // compute position
         if(offsetPositionSpace == Space.Self)
         {
             transform.position = target.TransformPoint(offsetPosition);
         }
         else
         {
             transform.position = target.position + offsetPosition;
         }
 
         // compute rotation
         if(lookAt)
         {
            // target.position = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.LookAt(target.position);
         }
         else
         {
            transform.rotation = target.rotation;
         }
     }

//     public Transform _lookTarget;

//     // Cache the target we're supposed to look at.  
//     public void LookAt(Transform target)
//     {
//     _lookTarget = target;
//     }

// // LateUpdate so it runs after any scripts/animation 
// // that might move _lookTarget this frame.
//     void LateUpdate()
//         {
//         if(_lookTarget != null)
//         {
//             Transform camera = Camera.main.transform;
//             Vector3 toTarget = _lookTarget.position - camera.position;

//             // This constructs a rotation looking in the direction of our target,
//             Quaternion targetRotation = Quaternion.LookRotation(toTarget);

//             // This blends the target rotation in gradually.
//             // Keep sharpness between 0 and 1 - lower values are slower/softer.
//             float sharpness = 0.1f;
//             camera.rotation = Quaternion.Lerp(camera.rotation, targetRotation, sharpness);

//             // This gives an "stretchy" damping where it moves fast when far
//             // away and slows down as it gets closer. You can also use 
//             // Quaternion.RotateTowards() to get a more consistent speed.
//         }
//     }
 }