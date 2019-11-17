using UnityEngine;

public class BallController : MonoBehaviour
{
    public float InputForceScale = 10;
    private Rigidbody RigidBody;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float HorizontalAxis = Input.GetAxis("Horizontal");
        float VerticalAxis = Input.GetAxis("Vertical");

        Vector3 force = 
            new Vector3(HorizontalAxis, 0, VerticalAxis) * InputForceScale;

        RigidBody.AddForce(force);
    }
}
