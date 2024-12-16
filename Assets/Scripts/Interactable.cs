using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected string promptMessage;
    [SerializeField] protected TextMeshProUGUI textField;
    [SerializeField] protected GameObject textBorder;

    public void BaseInteract()
    {
        Interact();
    }

    public string GetPromptMessage() => promptMessage;

    protected virtual void Interact()
    {
    }

    public void HandleLookAt()
    {
        textBorder.SetActive(true);
        textField.text = promptMessage;
        Debug.Log($"Interacted with {gameObject.name}");
    }

    public void HidePromptMessage()
    {
        textBorder.SetActive(false);
    }
}
