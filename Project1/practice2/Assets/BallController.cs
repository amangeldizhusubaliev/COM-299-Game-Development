using UnityEngine;

public class BallController : MonoBehaviour
{
    public float BallForceScale = 400;
    public float BallInitalAngle = 33;
    private Rigidbody RigidBody;
    
    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();

        Vector3 force = Quaternion.Euler(0, BallInitalAngle, 0) *
            Vector3.forward * BallForceScale;

        RigidBody.AddForce(force);
    }
}
