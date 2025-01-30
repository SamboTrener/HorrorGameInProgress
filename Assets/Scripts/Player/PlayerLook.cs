using UnityEngine;
using UnityEngine.Windows;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float sensitivity = 30f;

    private float _xRotation;

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
        _xRotation -= (mouseY * Time.deltaTime) * sensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -topDownLookDegree, topDownLookDegree);
        cam.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.Rotate(mouseX * Time.deltaTime * sensitivity * Vector3.up);
    }
}
