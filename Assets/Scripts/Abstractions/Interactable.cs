using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected AudioClip interactCue;
    [SerializeField] protected AudioClip cantInteractCue;
    [SerializeField] protected AudioClip interactSound;
    [SerializeField] Renderer interactableRenderer;

    Color lookAtColor = new Color(65f / 255f, 65f / 255f, 65f / 255f);

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        if(interactSound != null)
        {
            AudioSource.PlayClipAtPoint(interactSound, transform.position);
        }
    }

    public void HandleLookAt()
    {
        if (!PlayerHold.Instance.CheckIfCurrentHoldable(gameObject))
        {
            SetEmissionColor(lookAtColor);
        }
    }

    public void HandleStopLooking()
    {
        SetEmissionColor(new Color(0, 0, 0));
    }

    void SetEmissionColor(Color color)
    {
        if(interactableRenderer != null)
        {
            interactableRenderer.material.SetColor("_EmissionColor", color);
            interactableRenderer.material.EnableKeyword("_EMISSION");//This is a bug in unity
        }
    }
}
