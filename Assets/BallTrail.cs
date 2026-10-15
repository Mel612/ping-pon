using UnityEngine;

// Genera un rastro de "fantasmas" de la pelota que se desvanecen,
// imitando el efecto de movimiento del asset Simple Ping Pong.
public class BallTrail : MonoBehaviour
{
    public float spawnInterval = 0.025f;
    public float fadeDuration = 0.35f;
    public Color trailColor = new Color(0.933f, 0.2f, 0.6f, 0.55f);

    private SpriteRenderer ballSprite;
    private float timer;

    void Start()
    {
        ballSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnGhost();
        }
    }

    void SpawnGhost()
    {
        if (ballSprite == null) return;

        GameObject ghost = new GameObject("BallGhost");
        ghost.transform.position = transform.position;
        ghost.transform.rotation = transform.rotation;
        ghost.transform.localScale = transform.localScale;

        SpriteRenderer sr = ghost.AddComponent<SpriteRenderer>();
        sr.sprite = ballSprite.sprite;
        sr.sharedMaterial = ballSprite.sharedMaterial;
        sr.sortingLayerID = ballSprite.sortingLayerID;
        sr.sortingOrder = ballSprite.sortingOrder - 1;
        sr.color = trailColor;

        GhostFade fade = ghost.AddComponent<GhostFade>();
        fade.fadeDuration = fadeDuration;
    }
}
