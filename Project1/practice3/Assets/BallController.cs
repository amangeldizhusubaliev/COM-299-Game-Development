using UnityEngine;

public class BallController : MonoBehaviour
{
    public float BallForceScale = 400;
    private float BallInitalAngle;

    public int LastPlayer = -1;
    
    public AudioClip WallSound;
    public AudioClip PaddleSound;
    public AudioClip BallOutOfBounds;

    private Rigidbody RigidBody;
    private AudioSource audioSource;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
        if (LastPlayer != -1)
        {
            audioSource.PlayOneShot(BallOutOfBounds);
        } else
        {
            LastPlayer = Random.Range(0, 1) < 0.5 ? 1 : 2;
        }

        if (LastPlayer == 1)
        {
            BallInitalAngle = Random.Range(-45, -135);
        } else
        {
            BallInitalAngle = Random.Range(45, 135);
        }

        Vector3 force = Quaternion.Euler(0, BallInitalAngle, 0) *
            Vector3.forward * BallForceScale;

        RigidBody.AddForce(force);
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
