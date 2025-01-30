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
}