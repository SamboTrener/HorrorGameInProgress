using System;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityChanger : MonoBehaviour
{
    public static SensitivityChanger Instance {get; private set;}
    
    private Scrollbar _scrollbar;
    
    public Action OnSensitivityChanged;
    
    private void Awake()
    {
        Instance = this;
        _scrollbar = GetComponent<Scrollbar>();
        _scrollbar.onValueChanged.AddListener(ChangeSensitivity);
        _scrollbar.value = SaveLoadManager.GetSensitivityLevel();
    }
    
    private void ChangeSensitivity(float sens)
    {
        SaveLoadManager.SaveSensitivityLevel(sens);
        OnSensitivityChanged?.Invoke();
    }
}
