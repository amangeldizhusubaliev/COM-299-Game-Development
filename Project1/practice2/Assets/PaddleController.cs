using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float PaddleForceScale = 100;
    private Rigidbody RigidBody;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float Delta = Input.GetAxis("Horizontal");

        Vector3 force = new Vector3(0, 0, Delta) * 
            PaddleForceScale;

        RigidBody.AddForce(force);
    }
}
