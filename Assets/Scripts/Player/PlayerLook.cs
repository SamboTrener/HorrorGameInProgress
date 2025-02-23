using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Windows;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float sensitivityCoef = 10f;
    
    private float _sensitivity;
    private float _xRotation;
    
    private void Awake()    
    {
        _sensitivity = 1 + SaveLoadManager.GetSensitivityLevel() * sensitivityCoef; //не тестил
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
