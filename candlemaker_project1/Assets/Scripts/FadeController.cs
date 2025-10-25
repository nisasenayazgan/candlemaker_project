using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image blackOverlay; // Inspector’dan atanacak
    public float fadeDuration = 5f;
    private bool fadeOut = false;
    private float alpha = 1f;



    void Update()
    {
        if (fadeOut)
        {
            if (alpha > 0f)
            {
                alpha -= Time.deltaTime / fadeDuration;
                Color c = blackOverlay.color;
                c.a = Mathf.Clamp01(alpha);
                blackOverlay.color = c;
            }
            else
            {
                fadeOut = false;
                blackOverlay.gameObject.SetActive(false); // tamamen görünmez yap
            }
        }
    }

    public void StartFadeOut()
    {
        fadeOut = true;
    }
}
