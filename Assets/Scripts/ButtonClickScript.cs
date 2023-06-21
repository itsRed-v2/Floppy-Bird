using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private AudioSource source;

    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

	public void OnPointerDown(PointerEventData eventData)
	{
        source.pitch = 0.9f;
        source.Play();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
        // source.pitch = 0.8f;
        // source.Play();
	}


}
