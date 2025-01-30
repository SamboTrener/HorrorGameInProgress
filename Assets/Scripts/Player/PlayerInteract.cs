using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 2f;
    [SerializeField] private LayerMask mask;

    private Interactable _interactable;

    private void Update()
    {
        switch (PlayerStateMachine.Instance.PlayerState)
        {
            case PlayerState.Default:
                var ray = new Ray(cam.transform.position, cam.transform.forward);
                Debug.DrawRay(ray.origin, ray.direction * distance);
                if (Physics.Raycast(ray, out var hitInfo, distance, mask))
                {
                    if (_interactable)
                    {
                        ResetInteractable();
                    }
                    _interactable = hitInfo.collider.GetComponent<Interactable>();
                    _interactable.HandleLookAt();
                    if (InputManager.Instance.IsInteractTriggered())
                    {
                        _interactable.BaseInteract();
                    }
                }
                else if (_interactable)
                {
                    ResetInteractable();
                }
                break;
            case PlayerState.Hiding:
                if(_interactable)
                {
                    ResetInteractable();
                }
                if (InputManager.Instance.IsInteractTriggered())
                {
                    StartCoroutine(PlayerMotor.Instance.StopHiding());
                }
                break;
        }
    }

    private void ResetInteractable()
    {
        _interactable.HandleStopLooking();
        _interactable = null;
    }
}
