using UnityEngine;

public class BallController : MonoBehaviour
{
    public float BallForceScale = 400;
    public float BallInitalAngle = 33;

    public AudioClip WallSound;
    public AudioClip PaddleSound;

    private Rigidbody RigidBody;
    private AudioSource audioSource;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();

        Vector3 force = Quaternion.Euler(0, BallInitalAngle, 0) *
            Vector3.forward * BallForceScale;

        RigidBody.AddForce(force);

        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.CompareTag("Paddle"))
        {
            audioSource.PlayOneShot(PaddleSound);
        } 
        else if (gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(WallSound);
        }
    }
}
