using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Interactable
{
    [SerializeField] HoldableType neededHoldableSubj;
    [SerializeField] AudioClip[] cues;
    [SerializeField] float maxTimeCue;
    
    float timeCue = 0f;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(timeCue < maxTimeCue)
        {
            timeCue += Time.deltaTime;
        }
        else
        {
            timeCue = 0f;
            AudioSource.PlayClipAtPoint(cues[Random.Range(0, cues.Length)], transform.position);
        }
    }

    protected override void Interact()
    {
        base.Interact();

        if (PlayerHold.Instance.GetCurrentHoldableType() == neededHoldableSubj)
        {
            PlayerHold.Instance.DestroyCurrentHoldable();
            animator.SetTrigger("Move");
        }
        else
        {
            PlayerSounds.Instance.PlayCue(cantInteractCue);
        }
    }
}
