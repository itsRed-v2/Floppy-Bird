using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{

    public GameObject quitButton;

    public void Awake()
    {
        #if UNITY_WEBGL
            quitButton.SetActive(false);
        #endif
    }

    public void startGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void quitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void openSettings() {
        SceneManager.LoadScene("SettingsScene");
    }

}
