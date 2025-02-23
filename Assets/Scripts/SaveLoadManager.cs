using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoadManager
{
    private static float _volume = 0.5f;
    private static float _sensitivity  = 9f;

    public static void SaveSensitivityLevel(float sensitivity)
    {
        _sensitivity  = sensitivity;
        //Save
    }

    public static float GetSensitivityLevel() => _sensitivity;
    
    public static  void SaveVolumeLevel(float volume)
    {
        _volume = volume;
        //Save
    }

    public static float GetVolumeLevel() => _volume;
}
