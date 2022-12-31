using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] 
    LayerMask groundLayers;
    //[SerializeField]
    //private AudioClip jumpSound;

    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    //calculate press time
    public float jumpDistance = 6.0f; //max
    public float initialJumpDistance = 0.1f; //initial
    public float jumpDistanceIncrement = 0.4f; //rate
    float startTime;
    float calculatedJumpDistance;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    /*  private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            // Player has landed on a block
            // Do something here, such as increasing the player's score or spawning a new block
        }
    }*/


    void Update()
    {
        //horizontalInput = 1;
        //Move where they face
        //Vector3 movement = transform.forward * calculatedJumpDistance;


        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
             //Add gravity
             velocity.y += gravity * Time.deltaTime;
        }

        //calculate time button is down
            /*if (isGrounded && Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    startTime = Time.time;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    float timeHeld = Time.time - startTime;
                    float calculatedJumpDistance = initialJumpDistance + (timeHeld * jumpDistanceIncrement);
                 if (calculatedJumpDistance > jumpDistance)
                {
                    calculatedJumpDistance = jumpDistance;
                }
                //jumpy!!!
                Vector3 jumpMovement = transform.forward * calculatedJumpDistance + Vector3.up * 2f;
                characterController.Move(jumpMovement);
                }
            }*/

            //just for the computer WILL DELETE
               if (isGrounded && Input.GetButtonDown("Jump")) {
               
                    startTime = Time.time;
              }
                else if (Input.GetButtonUp("Jump"))
                {
                    float timeHeld = Time.time - startTime;
                    float calculatedJumpDistance = initialJumpDistance + (timeHeld * jumpDistanceIncrement);
                 if (calculatedJumpDistance > jumpDistance)
                {
                    calculatedJumpDistance = jumpDistance;
                }
                //jumpy!!!
                //audioclip
                Vector3 jumpMovement = transform.forward * calculatedJumpDistance + Vector3.up * 2f;
                characterController.Move(jumpMovement);
                }


        //vertical velocity
        characterController.Move(velocity * Time.deltaTime);

        //Set animator Grounded
        //animator.SetBool("IsGrounded",isGrounded);
    }
}


