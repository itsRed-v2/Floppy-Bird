using UnityEngine;

public class GameInit : MonoBehaviour
{
    private static bool initialized = false;

    void Awake()
    {
        if (!initialized) {
            initialized = true;
            initialize();
        }
    }

    private void initialize() {
        AudioListener.volume = Persistence.getVolume();
        // Application.targetFrameRate = 60;
    }

}
