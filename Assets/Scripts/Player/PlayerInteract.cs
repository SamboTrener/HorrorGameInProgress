using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float distance = 3f;
    [SerializeField] LayerMask mask;

    Interactable prevInteractable;

    private void Update()
    {
        var ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            prevInteractable = hitInfo.collider.GetComponent<Interactable>();
            if (prevInteractable != null)
            {
                prevInteractable.HandleLookAt();
                if (InputManager.Instance.IsInteractTriggered())
                {

                }
            }

        }
        else if(prevInteractable != null)
        {
            prevInteractable.HidePromptMessage();
            prevInteractable = null;
        }
    }
}
