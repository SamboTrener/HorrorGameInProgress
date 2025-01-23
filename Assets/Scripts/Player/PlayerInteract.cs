using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float distance = 2f;
    [SerializeField] LayerMask mask;

    Interactable interactable;

    private void Update()
    {
        var ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(interactable != null)
            {
                ResetInteractable();
            }
            interactable = hitInfo.collider.GetComponent<Interactable>();
            interactable.HandleLookAt();
            if (InputManager.Instance.IsInteractTriggered())
            {
                interactable.BaseInteract();
            }
        }
        else if (interactable != null)
        {
            ResetInteractable();
        }
    }

    void ResetInteractable()
    {
        interactable.HandleStopLooking();
        interactable = null;
    }
}
