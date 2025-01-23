using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndZone : MonoBehaviour
{
    [SerializeField] AudioClip noConditionCompletedCue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (GameManager.Instance.IsPowerOn)
            {
                //Победа
            }
            else
            {
                PlayerSounds.Instance.PlayCue(noConditionCompletedCue);
            }
        }
    }
}
