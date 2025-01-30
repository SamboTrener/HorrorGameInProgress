using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
    [SerializeField] protected string lookAtText;
    [SerializeField] protected AudioClip interactCue;
    [SerializeField] protected AudioClip cantInteractCue;
    [SerializeField] protected AudioClip interactSound;
    [SerializeField] private Renderer[] interactableRenderers;

    private readonly Color _lookAtColor = new Color(65f / 255f, 65f / 255f, 65f / 255f);

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        if(interactSound)
        {
            AudioSource.PlayClipAtPoint(interactSound, transform.position);
        }
    }

    public void HandleLookAt()
    {
        if (PlayerHold.Instance.CheckIfCurrentHoldable(gameObject))
            return;
        SetEmissionColor(_lookAtColor);
        UI.Instance.ShowText(lookAtText);
    }

    public void HandleStopLooking()
    {
        SetEmissionColor(new Color(0, 0, 0));
        switch (PlayerStateMachine.Instance.PlayerState)
        {
            case PlayerState.Default:
                UI.Instance.HideText();
                break;
            case PlayerState.Hiding:
                break;
        }
    }

    private void SetEmissionColor(Color color)
    {
        foreach(var interactableRenderer in interactableRenderers)
        {
            interactableRenderer.material.SetColor(EmissionColor, color);
            interactableRenderer.material.EnableKeyword("_EMISSION");//This is a bug in unity
        }
    }
}
