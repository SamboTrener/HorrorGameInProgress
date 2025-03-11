using UnityEngine;

public class Lever : Interactable
{
    private static readonly int LeverDown = Animator.StringToHash("LeverDown");
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void Interact()
    {
        base.Interact();
        gameObject.layer = LayerMask.NameToLayer("Default");
        PlayerSounds.Instance.PlayCue(interactCue);
        _animator.SetTrigger(LeverDown);
        GameManager.Instance.SwitchLever();
    }
}
