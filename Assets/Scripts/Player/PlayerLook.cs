using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float sensitivity = 30f;

    float xRotation = 0f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        xRotation -= (mouseY * Time.deltaTime) * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(mouseX * Time.deltaTime * sensitivity * Vector3.up);
    }
}
