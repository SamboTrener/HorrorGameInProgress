using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable
{
    [SerializeField] private Transform placeToHide;

    protected override void Interact()
    {
        PlayerMotor.Instance.Hide(placeToHide);
    }
}
