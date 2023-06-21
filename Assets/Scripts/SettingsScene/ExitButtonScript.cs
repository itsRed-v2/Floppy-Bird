using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
        this.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
        this.transform.localScale = Vector3.one;
	}

    public void exitSettings() {
        SceneManager.LoadScene("StartScene");
    }

}
