using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    PlayerInput playerInput;
    PlayerInput.OnFootActions onFoot;

    PlayerMotor motor;
    PlayerLook look;

    private void Awake()
    {
        Instance = this;
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
    }

    public bool IsInteractTriggered() => onFoot.Interact.triggered;

    private void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
