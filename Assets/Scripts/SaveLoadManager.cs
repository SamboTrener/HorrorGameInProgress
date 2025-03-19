using YG;

public static class SaveLoadManager
{
    public static void SaveSensitivityLevel(float sensitivity)
    {
        YG2.saves.sensitivity  = sensitivity;
        YG2.SaveProgress();
    }

    public static float GetSensitivityLevel() => YG2.saves.sensitivity;
    
    public static  void SaveVolumeLevel(float volume)
    {
        YG2.saves.volume = volume;
        YG2.SaveProgress();
    }

    public static float GetVolumeLevel() => YG2.saves.volume;
}
