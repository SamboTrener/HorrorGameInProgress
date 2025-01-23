using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Interactable
{
    protected override void Interact()
    {
        base.Interact();
        if (GameManager.Instance.DoneLeverCount < 3)
        {
            PlayerSounds.Instance.PlayCue(cantInteractCue);
        }
        else
        {
            GameManager.Instance.PowerOn();
            PlayerSounds.Instance.PlayCue(interactCue);
        }
    }
}
