using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public KeyCode moveUpKey = KeyCode.W;
    public KeyCode moveDownKey = KeyCode.S;
    public float yLimit = 3.8f;

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
        pos.y = Mathf.Clamp(pos.y, -yLimit, yLimit);
        transform.position = pos;
    }
}