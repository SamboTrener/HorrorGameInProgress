using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndZone : MonoBehaviour
{
    [SerializeField] private AudioClip noConditionCompletedCue;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (GameManager.Instance.IsPowerOn)
        {
            //Game end 
        }
        else
        {
            PlayerSounds.Instance.PlayCue(noConditionCompletedCue);
        }
    }
}
