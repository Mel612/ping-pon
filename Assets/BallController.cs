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

        // Elige una dirección aleatoria hacia la izquierda o derecha
        float x = Random.Range(0, 2) == 0 ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction * speed;
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