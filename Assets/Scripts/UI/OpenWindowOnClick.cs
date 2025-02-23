using System;
using UnityEngine;
using UnityEngine.UI;

public class OpenWindowOnClick : MonoBehaviour
{
    [SerializeField] private GameObject windowToOpen;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(() => windowToOpen.SetActive(true));
    }
}
