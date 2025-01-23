using UnityEngine;

public class Lever : Interactable
{
    Animator animator;

    bool isFirstInteraction;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isFirstInteraction = true;
    }

    protected override void Interact()
    {
        if (isFirstInteraction)
        {
            base.Interact();
            PlayerSounds.Instance.PlayCue(interactCue);
            animator.SetTrigger("LeverDown");
            GameManager.Instance.SwitchLever();
            isFirstInteraction = false;
        }
    }
}
