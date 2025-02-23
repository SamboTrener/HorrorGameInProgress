using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HideWindowOnClick : MonoBehaviour
{
    [SerializeField] private GameObject windowToHide;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(() => windowToHide.SetActive(false));
    }
}
