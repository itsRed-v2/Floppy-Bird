using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence
{

    public static int getHighScore() {
        return PlayerPrefs.GetInt("highscore", 0);
    }

    public static void setHighscore(int score) {
        PlayerPrefs.SetInt("highscore", score);
        PlayerPrefs.Save();
    }

    public static bool doShowFPS() {
        string setting = PlayerPrefs.GetString("showFPS", "False");
        return setting.Equals("True");
    }

    public static void setShowFPS(bool doShow) {
        string strValue = doShow.ToString();
        PlayerPrefs.SetString("showFPS", strValue);
        PlayerPrefs.Save();
    }

    public static float getVolume() {
        return PlayerPrefs.GetFloat("volume", 0.5f);
    }

    public static void setVolume(float volume) {
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

}
