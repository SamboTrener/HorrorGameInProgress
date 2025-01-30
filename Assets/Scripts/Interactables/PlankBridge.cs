using UnityEngine;

public class PlankBridge : Interactable
{
    [SerializeField] private BoxCollider invisibleWall;
    [SerializeField] private Material afterStandMaterial;

    private Renderer _plankBridgeRenderer;

    private void Start()
    {
        _plankBridgeRenderer =  GetComponent<Renderer>();
    }

    protected override void Interact()
    {
        if(PlayerHold.Instance.GetCurrentHoldableType() == HoldableType.Plank)
        {
            PlayerHold.Instance.DestroyCurrentHoldable();
            invisibleWall.enabled = false;
            _plankBridgeRenderer.material = afterStandMaterial;
            PlayerSounds.Instance.PlayCue(interactCue);
            gameObject.layer = 0;
        }
        else
        {
            PlayerSounds.Instance.PlayCue(cantInteractCue);
        }
    }
}
