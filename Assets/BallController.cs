using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 9f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    public void LaunchBall()
    {
        transform.position = Vector2.zero;
        rb.linearVelocity = Vector2.zero;

        float x = Random.Range(0, 2) == 0 ? -1f : 1f;
        // Mínimo ~20° de ángulo para evitar trayectorias casi horizontales
        float y = Random.Range(0.36f, 0.7f) * (Random.Range(0, 2) == 0 ? 1f : -1f);

        Vector2 direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 vel = rb.linearVelocity;
        float minY = speed * 0.3f;
        if (Mathf.Abs(vel.y) < minY)
        {
            vel.y = minY * (vel.y >= 0f ? 1f : -1f);
            rb.linearVelocity = vel.normalized * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GoalLeft"))
        {
            GameManager.Instance.ScorePlayer2(); // Punto para P2
            LaunchBall();
        }
        else if (collision.CompareTag("GoalRight"))
        {
            GameManager.Instance.ScorePlayer1(); // Punto para P1
            LaunchBall();
        }
    }
}