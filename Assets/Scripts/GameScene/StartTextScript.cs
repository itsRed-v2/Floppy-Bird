using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartTextScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float animationSpeed;

    void Update()
    {
        float angle = Time.timeSinceLevelLoad * animationSpeed;
        float alpha = (Mathf.Cos(angle) + 1) / 2;
        text.color = new Color(1, 1, 1, alpha);
    }

}
