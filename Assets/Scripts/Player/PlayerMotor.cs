using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void ProcessMove(Vector2 input)
    {
        var moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y;
        characterController.SimpleMove(speed * Time.deltaTime * transform.TransformDirection(moveDirection));
    }
}
