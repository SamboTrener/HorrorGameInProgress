using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    PlayerInput playerInput;
    PlayerInput.OnFootActions onFoot;

    PlayerMotor motor;
    PlayerLook look;
    PlayerState state;

    private void Awake()
    {
        Instance = this;
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
    }

    public void ChangePlayerState(PlayerState state) => this.state = state;

    public bool IsInteractTriggered() => onFoot.Interact.triggered;

    private void FixedUpdate()
    {
        switch (state)
        {
            case PlayerState.Default:
                motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
                break;
            case PlayerState.Hiding:
                break;
        }
    }

    private void LateUpdate()
    {
        switch (state)
        {
            case PlayerState.Default:
                look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
                break;
            case PlayerState.Hiding:
                look.ProcessHidingLook(onFoot.Look.ReadValue<Vector2>());
                break;
        }
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
