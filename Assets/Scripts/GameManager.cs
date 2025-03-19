using System;
using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject looseGameWindow;
    [SerializeField] private GameObject settingsWindow;

    public static GameManager Instance { get; private set; }
    public bool IsPowerOn { get; private set; }
    public int DoneLeverCount { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        YG2.MetricaSend("gameStart");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        IsPowerOn = false;
        UnpauseGame();
        DoneLeverCount = 0;
    }

    public void LooseGame()
    {
        YG2.InterstitialAdvShow();
        ChangeCursorState(true);
        looseGameWindow.SetActive(true);
        PlayerSounds.Instance.PlayLooseSound();
        Time.timeScale = 0f;
    }

    public void WinGame(GameObject gameEndWindow)
    {
        YG2.InterstitialAdvShow();
        YG2.MetricaSend("gameEnd");
        ChangeCursorState(true);
        gameEndWindow.SetActive(true);
        PlayerSounds.Instance.PlayWinSound();
        Time.timeScale = 0f;
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
        YG2.InterstitialAdvShow();
        
        settingsWindow.SetActive(true);

        if (settingsWindow.activeSelf) //Fixin strange bug
        {
            Debug.Log("setting window is active now");
            AudioListener.volume = 0f;
            ChangeCursorState(true);
            Time.timeScale = 0;
        }
    }

    public void UnpauseGame()
    {
        settingsWindow.SetActive(false);
        Debug.Log("setting window is not active now");

        AudioListener.volume = SaveLoadManager.GetVolumeLevel();
        ChangeCursorState(false);
        Time.timeScale = 1f;
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

    private void ChangeCursorState(bool isActive)
    {
        Cursor.visible = isActive;
        Cursor.lockState = isActive ? CursorLockMode.Confined : CursorLockMode.Locked;
    }
}