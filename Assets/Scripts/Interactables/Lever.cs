using UnityEngine;

public class Lever : Interactable
{
    private static readonly int LeverDown = Animator.StringToHash("LeverDown");
    private Animator _animator;

    private bool _isFirstInteraction;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isFirstInteraction = true;
    }

    protected override void Interact()
    {
        if (!_isFirstInteraction)
            return;
        base.Interact();
        PlayerSounds.Instance.PlayCue(interactCue);
        _animator.SetTrigger(LeverDown);
        GameManager.Instance.SwitchLever();
        _isFirstInteraction = false;
    }
}
