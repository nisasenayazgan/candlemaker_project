using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FirstAnimationController : MonoBehaviour
{
    public Image fireImage;                 // UI Image
    public TextMeshProUGUI fireText;        // TextMeshPro
    public AudioSource readAudio;           // Ses
    public float fadeDuration = 3f;         // Fade süresi (saniye)
    public string nextSceneName;            // Inspector’dan girilecek sonraki sahne adı

    private bool clicked = false;

    void Update()
    {
        if (!clicked && Input.GetMouseButtonDown(0)) // Sol click
        {
            clicked = true;
            StartCoroutine(FadeInAndLoadNextScene(fireImage, fireText, readAudio));
        }
    }

    System.Collections.IEnumerator FadeInAndLoadNextScene(Image img, TextMeshProUGUI text, AudioSource audio)
    {
        float t = 0f;

        Color imgColor = img.color;
        Color textColor = text.color;

        audio.Play();

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = t / fadeDuration;

            img.color = new Color(imgColor.r, imgColor.g, imgColor.b, alpha);
            text.color = new Color(textColor.r, textColor.g, textColor.b, alpha);

            yield return null;
        }

        // Fade tamamlandı → renkleri tam opak yap
        img.color = new Color(imgColor.r, imgColor.g, imgColor.b, 1f);
        text.color = new Color(textColor.r, textColor.g, textColor.b, 1f);

        // Sonraki sahneye geçiş
        SceneManager.LoadScene(nextSceneName);
    }
}
