using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float PaddleForceScale = 100;
    public float ForceAppliedToBallScale = 4;
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

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.CompareTag("Ball"))
        {
            GameObject ball = collision.gameObject;

            float shift = ball.transform.position.z - 
                transform.position.z;

            Vector3 force = new Vector3(shift, 0, 0) * 
                ForceAppliedToBallScale;

            ball.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
