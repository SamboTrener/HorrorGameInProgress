using System.Collections.Generic;
using UnityEngine;
using YG;

public class Lever : Interactable
{
    [SerializeField] private string id;
    private static readonly int LeverDown = Animator.StringToHash("LeverDown");
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void Interact()
    {
        var metricaParams = new Dictionary<string, string>
        {
            { "id", id }
        };
        
        YG2.MetricaSend("leverDown", metricaParams);
        
        base.Interact();
        gameObject.layer = LayerMask.NameToLayer("Default");
        PlayerSounds.Instance.PlayCue(interactCue);
        _animator.SetTrigger(LeverDown);
        GameManager.Instance.SwitchLever();
    }
}
