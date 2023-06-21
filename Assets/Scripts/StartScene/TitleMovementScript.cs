using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMovementScript : MonoBehaviour
{
    public RectTransform rectTransform;
    public float movementSpeed;
    public float centerY;
    public float amplitudeY;

    void Update()
    {
        float angle = Time.timeSinceLevelLoad * movementSpeed;
        float titleHeight = Mathf.Sin(angle) * amplitudeY + centerY;

        rectTransform.localPosition = new Vector3(0, titleHeight, 0);
    }
}
