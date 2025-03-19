using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.Windows;
using YG;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float sensitivityCoef = 10f;
    [SerializeField] private float mobileSensitivityCoef = 100f;
    
    private float _sensitivity;
    private float _xRotation;
    
    private void Awake()
    {  
        ChangeSensitivity();
    }

    private void Start()
    {
        SensitivityChanger.Instance.OnSensitivityChanged += ChangeSensitivity;
    }

    private void OnDestroy()
    {
        SensitivityChanger.Instance.OnSensitivityChanged -= ChangeSensitivity;
    }

    private void ChangeSensitivity()
    {
        if (YG2.envir.isMobile)
        {
            _sensitivity = 1 + SaveLoadManager.GetSensitivityLevel() * mobileSensitivityCoef;
        }
        else
        {
            _sensitivity = 1 + SaveLoadManager.GetSensitivityLevel() * sensitivityCoef;
        }
    }
    
    public void ProcessLook(Vector2 input)
    {
        ProcessLookCommon(input, 80);
    }

    public void ProcessHidingLook(Vector2 input)
    {
        ProcessLookCommon(input, 0);
    }

    private void ProcessLookCommon(Vector2 input, float topDownLookDegree)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        _xRotation -= (mouseY * Time.deltaTime) * _sensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -topDownLookDegree, topDownLookDegree);
        cam.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.Rotate(mouseX * Time.deltaTime * _sensitivity * Vector3.up);
    }
}
