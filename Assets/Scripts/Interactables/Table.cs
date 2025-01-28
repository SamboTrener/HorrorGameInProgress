using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable
{
    [SerializeField] float heightOffset;
    [SerializeField] Transform placeToHide;

    protected override void Interact()
    {
        Debug.Log("Interaction");
        InputManager.Instance.ChangePlayerState(PlayerState.Hiding);
        InputManager.Instance.gameObject.transform.position = placeToHide.position;
    }
}
