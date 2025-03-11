using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndZone : MonoBehaviour
{
    [SerializeField] private AudioClip noConditionCompletedCue;
    [SerializeField] private GameObject gameEndWindow;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (GameManager.Instance.IsPowerOn)
        {
            gameEndWindow.SetActive(true);
            PlayerSounds.Instance.PlayWinSound();
            Time.timeScale = 0f;
        }
        else
        {
            PlayerSounds.Instance.PlayCue(noConditionCompletedCue);
        }
    }
}
