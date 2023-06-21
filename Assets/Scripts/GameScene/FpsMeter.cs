using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FpsMeter : MonoBehaviour
{
    private TextMeshProUGUI textField;

    public float measurePeriod;
    private int frameCounter;
    private float timer;

    void Start()
    {
        textField = gameObject.GetComponent<TextMeshProUGUI>();
        timer = 0;
        frameCounter = 0;

        updateVisibility();
    }

    void Update()
    {
        frameCounter++;
        timer += Time.deltaTime;

        if (timer >= measurePeriod) {
            int fps = Mathf.RoundToInt(frameCounter / timer);
            displayFps(fps);

            timer = 0;
            frameCounter = 0;
        }
    }

    private void displayFps(int fps) {
        textField.text = "FPS: " + fps;
    }

    public void updateVisibility() {
        bool active = Persistence.doShowFPS();
        gameObject.SetActive(active);
    }

}
