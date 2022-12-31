using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;

    private Vector3 offset;
    
    //I want a switch/if method so the camera moves differently depending where the block spawns, so that the target is in view
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        //prolly need 2 scenarios for this; Lerp = smooth
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x,0,target.position.z) + offset, Time.deltaTime*3);
    }
}
