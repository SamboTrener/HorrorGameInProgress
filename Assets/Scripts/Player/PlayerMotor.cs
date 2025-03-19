using System.Collections;
using UnityEngine;
using YG;

public class PlayerMotor : MonoBehaviour
{
    public static PlayerMotor Instance { get; private set; }

    [SerializeField] private float speed = 5f;

    private CharacterController _characterController;
    private Vector3 _beforeHidePosition;

    public bool IsMoving { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        YG2.TryGetFlagAsFloat("playerSpeed", out speed);
        _characterController = GetComponent<CharacterController>();
    }

    public void ProcessMove(Vector2 input)
    {
        var moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y;
        IsMoving = moveDirection != Vector3.zero;
        _characterController.SimpleMove(speed * Time.deltaTime * transform.TransformDirection(moveDirection));
    }

    public void Hide(Transform placeToHide)
    {
        PlayerStateMachine.Instance.ChangePlayerState(PlayerState.Hiding);
        _beforeHidePosition = gameObject.transform.position;
        gameObject.transform.position = placeToHide.position;
    }

    public IEnumerator StopHiding()
    {
        gameObject.transform.position = _beforeHidePosition;
        yield return new WaitForFixedUpdate(); //Start handle movements ONLY after position changed
        PlayerStateMachine.Instance.ChangePlayerState(PlayerState.Default);
    }
}
