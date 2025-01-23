using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlank : Holdable
{
    [SerializeField] AudioClip successInteractSound;

    bool isStatic = true;

    protected override void Interact()
    {
        if (!isStatic)
        {
            base.Interact();
        }
        else if (PlayerHold.Instance.GetCurrentHoldableType() == HoldableType.ClawHammer)
        {
            AudioSource.PlayClipAtPoint(successInteractSound, transform.position);
            GetComponent<Rigidbody>().isKinematic = false;
            isStatic = false; 
        }
        else
        {
            PlayerSounds.Instance.PlayCue(cantInteractCue);
        }
    }
}
