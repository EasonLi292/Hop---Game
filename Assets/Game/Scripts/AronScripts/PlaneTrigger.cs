using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player") {
            FindObjectOfType<LevelManager>().GameOver();
        }
    }
}
