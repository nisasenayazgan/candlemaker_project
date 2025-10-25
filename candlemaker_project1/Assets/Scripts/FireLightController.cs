using UnityEngine;

public class FireLightController : MonoBehaviour
{
    public SpriteRenderer lightSprite; // Işık sprite'ı
    public float fadeDuration = 5f;    // Fade-in süresi
    public float maxScale = 1.5f;      // Maksimum büyüme
    private bool isLit = false;
    private float currentAlpha = 0f;
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;

        // Başta görünmez ama obje sahnede var
        Color c = lightSprite.color;
        c.a = 0f;            // alpha 0
        lightSprite.color = c;
        transform.localScale = initialScale * 1.1f; // çok küçük
    }

    void Update()
    {
        if (isLit)
        {
            // Alpha artışı
            if (currentAlpha < 1f)
            {
                currentAlpha += Time.deltaTime / fadeDuration;
                Color c = lightSprite.color;
                c.a = Mathf.Clamp01(currentAlpha);
                lightSprite.color = c;
            }

            // Scale artışı
            if (transform.localScale.x < initialScale.x * maxScale)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, initialScale * maxScale, Time.deltaTime / fadeDuration);
            }
        }
    }

    public void LightUp()
    {
        isLit = true; // Obje sahnede kalacak, sadece alpha ve scale artacak
    }
}
