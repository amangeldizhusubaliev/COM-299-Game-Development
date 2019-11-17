using UnityEngine;

public class SecondPaddleController : MonoBehaviour
{
    public float PaddleForceScale = 100;
    private Rigidbody RigidBody;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float Delta = Input.GetAxis("SecondPlayer");

        Vector3 force = new Vector3(0, 0, Delta) * 
            PaddleForceScale;

        RigidBody.AddForce(force);
    }
}
