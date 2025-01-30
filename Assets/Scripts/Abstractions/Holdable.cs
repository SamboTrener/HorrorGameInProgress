using UnityEngine;

public class Holdable : Interactable
{
    [SerializeField] private HoldableType type;
    [SerializeField] private Quaternion inHandRotationOffset;

    public Quaternion GetInHandRotationOffset()
    {
        return inHandRotationOffset;
    }

    public HoldableType GetHoldableType() => type;

    protected override void Interact()
    {
        base.Interact();
        PlayerHold.Instance.TakeHoldable(this);
        HandleStopLooking();
        if(interactCue != null)
        {
            PlayerSounds.Instance.PlayCue(interactCue);
        }
    }
}
