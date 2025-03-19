using UnityEngine;
using YG;

public class Npc : Interactable
{
    private static readonly int Move = Animator.StringToHash("Move");
    [SerializeField] private HoldableType neededHoldableSubj;
    [SerializeField] private AudioClip[] cues;
    [SerializeField] private float maxTimeCue;

    private float _timeCue;
    private Animator _animator;
    private bool _isSatisfied;
    private float _cuesVolume = 0.3f;

    private void Start()
    {
        YG2.TryGetFlagAsFloat("maxTimeNpcCue", out maxTimeCue);
        YG2.TryGetFlagAsFloat("npcVolume", out _cuesVolume);
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isSatisfied) return;
        
        if(_timeCue < maxTimeCue)
        {
            _timeCue += Time.deltaTime;
        }
        else
        {
            _timeCue = 0f;
            AudioSource.PlayClipAtPoint(cues[Random.Range(0, cues.Length)], transform.position, _cuesVolume);
        }
    }

    protected override void Interact()
    {
        base.Interact();

        if (PlayerHold.Instance.GetCurrentHoldableType() == neededHoldableSubj)
        {
            PlayerHold.Instance.DestroyCurrentHoldable();
            AudioSource.PlayClipAtPoint(interactCue, transform.position, _cuesVolume);
            _animator.SetTrigger(Move);
            _isSatisfied = true;
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
        else
        {
            PlayerSounds.Instance.PlayCue(cantInteractCue);
        }
    }
}
