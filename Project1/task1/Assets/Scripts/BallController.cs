using System;
using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float BallForceScale = 400;
    public float BallMaximumSpeed = 50;
    private float BallInitalAngle;

    public int LastPlayer = -1;
    
    public AudioClip WallSound;
    public AudioClip PaddleSound;
    public AudioClip BallOutOfBounds;

    private Rigidbody RigidBody;
    private AudioSource audioSource;

    public float PauseOnStart = 3.5f;
    
    private bool isCoroutineExecuting = false;

    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
        {
            yield break;
        }

        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }

    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        if (LastPlayer != -1)
        {
            audioSource.PlayOneShot(BallOutOfBounds);
        }
        else
        {
            LastPlayer = UnityEngine.Random.Range(0, 1) < 0.5 ? 1 : 2;
        }

        StartCoroutine(ExecuteAfterTime(PauseOnStart, () =>
        {
            if (LastPlayer == 1)
            {
                BallInitalAngle = UnityEngine.Random.Range(-45, -135);
            }
            else
            {
                BallInitalAngle = UnityEngine.Random.Range(45, 135);
            }

            Vector3 force = Quaternion.Euler(0, BallInitalAngle, 0) *
                Vector3.forward * BallForceScale;

            RigidBody.AddForce(force);
        }));
    }

    float GetRigidBodyVelocity()
    {
        float deltax = RigidBody.velocity[0];
        float deltaz = RigidBody.velocity[2];

        return Mathf.Sqrt(deltax * deltax + deltaz * deltaz);
    }

    void FixedUpdate()
    {
        float currentVelocity = GetRigidBodyVelocity();
        
        if (currentVelocity > BallMaximumSpeed)
        {
            float coefficient = (currentVelocity - BallMaximumSpeed) /
                currentVelocity * -1;
            Vector3 force = RigidBody.velocity * coefficient;

            RigidBody.AddForce(force);
        }
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
