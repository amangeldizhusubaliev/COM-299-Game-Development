using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float BallForceScale = 100;
    private Rigidbody RigidBody;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
        
        //Vector3 force = new Vector3()
    }
}
