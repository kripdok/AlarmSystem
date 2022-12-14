using UnityEngine;

public class CameraСontrol : MonoBehaviour
{
    [SerializeReference] private float _mouseSensivity = 100.0f;
    [SerializeReference] private Transform _playerBody;
    private float _xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensivity * Time.deltaTime;
        _playerBody.Rotate(Vector3.up * mouseX);
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation,0f,0f);
    }
}
