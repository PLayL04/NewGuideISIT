using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float rotationSensivity = 1f; // �������� �������� ������
    private CharacterController characterController; // ����������
    private Camera camera; // ������
    private Vector2 delta; // ��� ���� � inputsystem
    private float cameraX = 0f; // ������� ��������� ������ �� x
    private float playerY = 0f; // ������� ��������� ������ �� y

    private void Start()
    {
        camera = GetComponentInChildren<Camera>(); // �������� ������
        characterController = GetComponent<CharacterController>(); // �������� ����������
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; // ��������� ������
    }

    private void Update()
    {
        // ���������� �������� � vector2
        cameraX -= delta.y * rotationSensivity * Time.deltaTime;
        playerY += delta.x * rotationSensivity * Time.deltaTime;

        // ������������ �������� ������ �� x
        cameraX = Mathf.Clamp(cameraX, -85f, 85f);

        // ������������ ������ � ���������
        camera.transform.localRotation = Quaternion.Euler(cameraX, 0f, 0f);
        characterController.transform.rotation = Quaternion.Euler(0f, playerY, 0f);
    }

    public void OnLookTrigger(InputAction.CallbackContext context)
    {
        delta = context.ReadValue<Vector2>(); // ��������� vector2
    }
}
