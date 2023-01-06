using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingController : MonoBehaviour
{
    // Storing Force Energy
    public float minimumEnergy = 3f; 
    public float maximumEnergy = 15f;
    private float storedEnergy = 0.0f;
   
    private Rigidbody rb; // The player's rigidbody component

    // Movement Directions
    private Vector3 diagonalZ;
    private Vector3 diagonalX;
    private bool movingForward = true;

    private bool canMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        diagonalZ = new Vector3(0, 1, 1);
        diagonalX = new Vector3(1, 1, 0);
        canMove = true;

        storedEnergy = minimumEnergy;
    }

    void Update()
    {
        // Check if the mouse button is held down
        if (Input.GetMouseButton(0) && canMove)
        {
            storedEnergy += Time.deltaTime*3;    
        }

        if (Input.GetMouseButtonUp(0) && canMove) {
            if (movingForward)
            {
                // Move the player Forward at the specified movement speed
                rb.AddForce(diagonalZ * storedEnergy, ForceMode.Impulse);
            } else {
                // Move the player Right at the specified movement speed 
                rb.AddForce(diagonalX * storedEnergy, ForceMode.Impulse);
            }

            print(storedEnergy);
            storedEnergy = minimumEnergy;
            SetCanMove(false);
        }
    }

    public void SetMovementForward(bool forward) {
        movingForward = forward;
    }

    public void SetCanMove(bool move) {
        canMove = move;
    }
}
