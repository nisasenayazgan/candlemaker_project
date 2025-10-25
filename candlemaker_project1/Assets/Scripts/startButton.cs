using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public string nextSceneName; // Geçmek istediğimiz sahnenin ismi

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
