using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public KeyCode moveUpKey = KeyCode.W;
    public KeyCode moveDownKey = KeyCode.S;
    // Límites asimétricos: el borde superior deja espacio para la ScoreBar.
    public float topLimit = 2.6f;
    public float bottomLimit = 3.6f;

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(moveUpKey))
        {
            pos.y += speed * Time.deltaTime;
        }
        else if (Input.GetKey(moveDownKey))
        {
            pos.y -= speed * Time.deltaTime;
        }

        // Evita que la paleta se salga por arriba o por abajo
        pos.y = Mathf.Clamp(pos.y, -bottomLimit, topLimit);
        transform.position = pos;
    }
}