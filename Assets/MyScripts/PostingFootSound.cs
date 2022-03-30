using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PostingFootSound : MonoBehaviour
    {
        private float speed;
        Vector3 lastPosition;
        Vector3 oldPosition;

        private bool previousGrounded; 
        public LayerMask GroundLayer; //Specify ground layer
        Vector3 groundCheck;

    void Start()
    {
        groundCheck = new Vector3(0f, -0.1f, 0f);
    }

    void FixedUpdate()
        {
            speed = Vector3.Distance(oldPosition, transform.position) * 100f;
            oldPosition = transform.position;
            AkSoundEngine.SetRTPCValue("ToeSpeed", speed, gameObject);

            PostingMovementEvent();            
        }

    bool RayCastGrounded()
        {
            RaycastHit grounded;
            if (Physics.Raycast(transform.position, groundCheck, out grounded, 0.1f, GroundLayer))
            {
                Debug.DrawRay(transform.position, groundCheck, Color.red, 1);
                if (grounded.transform != null)
                {
                    return true;                    
                }
                else
                {
                    return false;                   
                }
            }

            return false;
        }

    void PostingMovementEvent()
        {
            if (RayCastGrounded() && !previousGrounded)
            {
                AkSoundEngine.PostEvent("Player_Footstep", gameObject);
            }

            previousGrounded = RayCastGrounded();
        }
    }
