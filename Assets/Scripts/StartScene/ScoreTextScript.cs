using UnityEngine;
using TMPro;

public class ScoreTextScript : MonoBehaviour
{

    void Start()
    {
        TextMeshProUGUI textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = "Your high score: " + Persistence.getHighScore();
    }

}
