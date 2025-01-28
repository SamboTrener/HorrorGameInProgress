using UnityEngine;
using UnityEngine.Windows;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float sensitivity = 30f;

    float xRotation = 0f;

    public void ProcessLook(Vector2 input)
    {
        ProcessLookCommon(input, 80);
    }

    public void ProcessHidingLook(Vector2 input)
    {
        ProcessLookCommon(input, 0);
    }

    void ProcessLookCommon(Vector2 input, float topDownLookDegree)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        xRotation -= (mouseY * Time.deltaTime) * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -topDownLookDegree, topDownLookDegree);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(mouseX * Time.deltaTime * sensitivity * Vector3.up);
    }
}
