using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class ScreenShotScript : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            screen();
        }
    }

    [ContextMenu("Take screenshot")]
    public void screen() {
        Directory.CreateDirectory("Assets/screenshots");
        string[] files = Directory.GetFiles("Assets/screenshots");

        int biggestNumber = 0;
        foreach (string s in files) {
            Match m = Regex.Match(s, @"screenshot-(\d+).png");
            if (m.Success) {
                int screenNumber = int.Parse(m.Groups[1].Value);
                if (biggestNumber < screenNumber) {
                    biggestNumber = screenNumber;
                }
            }
        }
        biggestNumber++;

        string name = "screenshot-" + biggestNumber + ".png";
        string path = "Assets/screenshots/" + name;
        ScreenCapture.CaptureScreenshot(path);
        Debug.Log("Screen saved at : " + path);
    }

}
