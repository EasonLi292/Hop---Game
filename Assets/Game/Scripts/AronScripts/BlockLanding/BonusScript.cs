using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    private bool landed;

    // Start is called before the first frame update
    void Start()
    {
        landed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            // Bonus
            if (!landed) {
                landed = true;
            } 
        }
    }

    public bool PLTriggered() {
        return landed;
    }
}
