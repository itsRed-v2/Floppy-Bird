using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashDisplayScript : MonoBehaviour
{

    public Image circle;
    public Image arrow;
    public GameObject endDot;
    
    [Range(0, 1)]
    public float value;

    void OnValidate()
    {
        Display(value);
    }

    public void Display(float val) {
        this.value = val;
        
        circle.fillAmount = val;

        bool isFull = (val == 1);
        arrow.enabled = isFull;

        float rotation = val * -360;
        endDot.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

}
