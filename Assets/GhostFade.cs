using UnityEngine;

// Desvanece y encoge un fantasma del rastro de la pelota, luego lo destruye.
public class GhostFade : MonoBehaviour
{
    public float fadeDuration = 0.35f;

    private SpriteRenderer sr;
    private float elapsed;
    private Color startColor;
    private Vector3 startScale;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startColor = sr.color;
        startScale = transform.localScale;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(elapsed / fadeDuration);

        Color c = startColor;
        c.a = Mathf.Lerp(startColor.a, 0f, t);
        sr.color = c;

        transform.localScale = Vector3.Lerp(startScale, startScale * 0.3f, t);

        if (elapsed >= fadeDuration)
        {
            Destroy(gameObject);
        }
    }
}
