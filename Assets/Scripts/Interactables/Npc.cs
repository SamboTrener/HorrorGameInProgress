using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Interactable
{
    private static readonly int Move = Animator.StringToHash("Move");
    [SerializeField] private HoldableType neededHoldableSubj;
    [SerializeField] private AudioClip[] cues;
    [SerializeField] private float maxTimeCue;

    private float _timeCue = 0f;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_timeCue < maxTimeCue)
        {
            _timeCue += Time.deltaTime;
        }
        else
        {
            _timeCue = 0f;
            AudioSource.PlayClipAtPoint(cues[Random.Range(0, cues.Length)], transform.position);
        }
    }

    protected override void Interact()
    {
        base.Interact();

        if (PlayerHold.Instance.GetCurrentHoldableType() == neededHoldableSubj)
        {
            PlayerHold.Instance.DestroyCurrentHoldable();
            _animator.SetTrigger(Move);
        }
        else
        {
            PlayerSounds.Instance.PlayCue(cantInteractCue);
        }
    }
}
