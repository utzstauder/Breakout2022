using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialSpeed = 10f;
    
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        LaunchBall();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        ResetBall();
        LaunchBall();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            float hitDistance = transform.position.x - col.transform.position.x;
            float normalizedHitDistance = hitDistance / col.collider.bounds.extents.x;
            // print(normalizedHitDistance);

            Vector2 newDirection = rb.velocity.normalized;
            newDirection.x += normalizedHitDistance;
            newDirection.Normalize();

            rb.velocity = newDirection * rb.velocity.magnitude;
        }
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero;
        rb.velocity = Vector2.zero;
    }
    
    private void LaunchBall()
    {
        rb.velocity = Vector2.up * initialSpeed;
    }
}