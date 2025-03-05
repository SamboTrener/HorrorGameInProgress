using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    private Scrollbar _scrollbar;
    
    private void Awake()
    {
        _scrollbar = GetComponent<Scrollbar>();
        _scrollbar.onValueChanged.AddListener(ChangeVolume);
        _scrollbar.value = SaveLoadManager.GetVolumeLevel();
    }
    
    private void ChangeVolume(float volume)
    {
        SaveLoadManager.SaveVolumeLevel(volume);
        AudioListener.volume = volume;
    }
}
