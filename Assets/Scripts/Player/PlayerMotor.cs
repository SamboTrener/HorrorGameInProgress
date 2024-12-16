using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    CharacterController characterController;
    Vector3 playerVelocity;

    bool isGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        var moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y;
        characterController.Move(speed * Time.deltaTime * transform.TransformDirection(moveDirection));

        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
