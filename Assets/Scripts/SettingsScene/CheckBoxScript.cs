using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckBoxScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite uncheckedSprite;
    public Sprite checkedSprite;
    public Image imageComponent;
    public AudioSource audioSource;
    public GameObject fpsDisplay;

    public bool isChecked {
        get {
            return Persistence.doShowFPS();
        }
        set {
            Persistence.setShowFPS(value);
        }
    }

    void Start()
    {
        updateSprite();
    }

    public void onBoxClick() {
        isChecked = !isChecked;
        updateSprite();
        fpsDisplay.GetComponent<FpsMeter>().updateVisibility();
    }

    public void OnPointerDown(PointerEventData eventData)
	{
		audioSource.pitch = 0.9f;
        audioSource.Play();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
        audioSource.pitch = 0.8f;
        audioSource.Play();
	}

    private void updateSprite() {
        imageComponent.sprite = isChecked ? checkedSprite : uncheckedSprite;
    }

}
