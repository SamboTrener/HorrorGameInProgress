using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private static readonly int OpenDoor = Animator.StringToHash("OpenDoor");
    private Animator _animator;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
    }

    protected override void Interact()
    {
        if(PlayerHold.Instance.GetCurrentHoldableType() == HoldableType.Key)
        {
            base.Interact();
            _animator.SetTrigger(OpenDoor);
            _boxCollider.enabled = false;
            PlayerHold.Instance.DestroyCurrentHoldable();
        }
        else
        {
            PlayerSounds.Instance.PlayCue(cantInteractCue);
        }
    }
}
