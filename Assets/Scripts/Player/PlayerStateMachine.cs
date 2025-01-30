using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerStateMachine Instance {get; private set;}
    public PlayerState PlayerState { get; private set; }
    
    public Action OnStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangePlayerState(PlayerState state) 
    {
        PlayerState = state;
        OnStateChanged?.Invoke();
    } 
}
