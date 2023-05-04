using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // скорость перемещения
    private float gravity = 9.8f; // гравитация
    private CharacterController characterController; // контроллер
    private Vector2 vector; // для ввода с inputsystem
    private Vector3 velocity; // для падения
    private void Start()
    {
        characterController = GetComponent<CharacterController>(); // получаем контроллер
    }

    private void Update()
    {
        velocity += Vector3.down * gravity * Time.deltaTime; // назначаем ускорение
        if (characterController.isGrounded) // если на земле
            velocity = Vector3.zero; // обнуляем ускорение
        characterController.Move(velocity * Time.deltaTime); // роняем на землю с ускорением

        // создаем вектор и преобразуем локальные координаты в глобальные (чтобы можно было поворачивать вслед за камерой)
        Vector3 move = characterController.transform.TransformDirection(vector.x, 0f, vector.y); 
        move *= moveSpeed * Time.deltaTime; // домножаем вектор на скорость
        characterController.Move(move); // перемещаем
    }

    public void OnMoveTrigger(InputAction.CallbackContext context)
    {
        vector = context.ReadValue<Vector2>(); // читаем vector2
    }
}
