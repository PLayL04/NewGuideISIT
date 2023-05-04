using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float rotationSensivity = 1f; // скорость поворота камеры
    private CharacterController characterController; // контроллер
    private Camera camera; // камера
    private Vector2 delta; // для ввод с inputsystem
    private float cameraX = 0f; // текущее положение камеры по x
    private float playerY = 0f; // текущее положение игрока по y

    private void Start()
    {
        camera = GetComponentInChildren<Camera>(); // получаем камеру
        characterController = GetComponent<CharacterController>(); // получаем контроллер
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; // блокируем курсор
    }

    private void Update()
    {
        // записываем значения с vector2
        cameraX -= delta.y * rotationSensivity * Time.deltaTime;
        playerY += delta.x * rotationSensivity * Time.deltaTime;

        // ограничиваем вращение камеры по x
        cameraX = Mathf.Clamp(cameraX, -85f, 85f);

        // поворачиваем камеру и персонажа
        camera.transform.localRotation = Quaternion.Euler(cameraX, 0f, 0f);
        characterController.transform.rotation = Quaternion.Euler(0f, playerY, 0f);
    }

    public void OnLookTrigger(InputAction.CallbackContext context)
    {
        delta = context.ReadValue<Vector2>(); // считываем vector2
    }
}
