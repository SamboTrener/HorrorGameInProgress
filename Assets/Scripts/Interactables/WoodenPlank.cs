using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlank : Holdable
{
    [SerializeField] private AudioClip successInteractSound;

    private bool _isStatic = true;
    private Rigidbody _rigidbody;

    private readonly string lookAtTextAfterInteraction = "Взять";
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected override void Interact()
    {
        if (!_isStatic)
        {
            base.Interact();
        }
        else if (PlayerHold.Instance.GetCurrentHoldableType() == HoldableType.ClawHammer)
        {
            AudioSource.PlayClipAtPoint(successInteractSound, transform.position);
            lookAtText = lookAtTextAfterInteraction;
            _rigidbody.isKinematic = false;
            _isStatic = false; 
        }
        else
        {
            PlayerSounds.Instance.PlayCue(cantInteractCue);
        }
    }
}
