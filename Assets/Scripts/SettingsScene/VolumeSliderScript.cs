using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeSliderScript : MonoBehaviour, IPointerUpHandler
{
    public Slider slider;
    public TextMeshProUGUI valueText;
    public AudioSource source;

	public void OnPointerUp(PointerEventData eventData)
	{
        source.Play();
	}

	void Start()
    {
        slider.value = AudioListener.volume * 100;
        valueText.text = slider.value.ToString();

        slider.onValueChanged.AddListener((float newValue) => {
            valueText.text = newValue.ToString();
            AudioListener.volume = newValue / 100;

            Persistence.setVolume(AudioListener.volume);
        });
    }

}
