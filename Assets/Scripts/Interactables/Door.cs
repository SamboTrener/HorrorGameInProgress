using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void Interact()
    {
        if(PlayerHold.Instance.GetCurrentHoldableType() == HoldableType.Key)
        {
            base.Interact();
            animator.SetTrigger("OpenDoor");
            GetComponent<BoxCollider>().enabled = false;
            PlayerHold.Instance.DestroyCurrentHoldable();
        }
        else
        {
            PlayerSounds.Instance.PlayCue(cantInteractCue);
        }
    }
}
