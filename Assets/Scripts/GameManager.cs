using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsPowerOn { get; private set; }
    public int DoneLeverCount { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        IsPowerOn = false;
        DoneLeverCount = 0;
    }

    public void SwitchLever()
    {
        DoneLeverCount++;
    }

    public void PowerOn()
    {
        IsPowerOn = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        SettingsMenu.Instance.gameObject.SetActive(true);
        AudioListener.volume = 0f;
    }
    
    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        SettingsMenu.Instance.gameObject.SetActive(false);
        AudioListener.volume = 1f;
    }

    public void ChangePauseState()
    {
        if (Time.timeScale == 0f)
        {
            UnpauseGame();
        }
        else
        {
            PauseGame();
        }
    }
}