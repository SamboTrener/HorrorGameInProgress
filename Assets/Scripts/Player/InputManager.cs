using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFoot;

    private PlayerMotor _motor;
    private PlayerLook _look;

    private void Awake()
    {
        Instance = this;
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;
        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();
    }

    public bool IsInteractTriggered() => _onFoot.Interact.triggered;

    private void FixedUpdate()
    {
        switch (PlayerStateMachine.Instance.PlayerState)
        {
            case PlayerState.Default:
                _motor.ProcessMove(_onFoot.Movement.ReadValue<Vector2>());
                break;
            case PlayerState.Hiding:
                break;
        }
    }

    private void LateUpdate()
    {
        switch (PlayerStateMachine.Instance.PlayerState)
        {
            case PlayerState.Default:
                _look.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
                break;
            case PlayerState.Hiding:
                _look.ProcessHidingLook(_onFoot.Look.ReadValue<Vector2>());
                break;
        }
    }

    private void OnEnable()
    {
        _onFoot.Enable();
    }

    private void OnDisable()
    {
        _onFoot.Disable();
    }
}
