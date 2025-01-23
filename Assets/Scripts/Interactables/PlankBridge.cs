using UnityEngine;

public class PlankBridge : Interactable
{
    [SerializeField] BoxCollider invisibleWall;
    [SerializeField] Material afterStandMaterial;

    Renderer plankBridgeRenderer;

    private void Start()
    {
        plankBridgeRenderer =  GetComponent<Renderer>();
    }

    protected override void Interact()
    {
        if(PlayerHold.Instance.GetCurrentHoldableType() == HoldableType.Plank)
        {
            PlayerHold.Instance.DestroyCurrentHoldable();
            invisibleWall.enabled = false;
            plankBridgeRenderer.material = afterStandMaterial;
            PlayerSounds.Instance.PlayCue(interactCue); //Если будет
            gameObject.layer = 0;
        }
        else
        {
            PlayerSounds.Instance.PlayCue(cantInteractCue);
        }
    }
}
