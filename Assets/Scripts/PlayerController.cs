using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� �����������
    private float gravity = 9.8f; // ����������
    private CharacterController characterController; // ����������
    private Vector2 vector; // ��� ����� � inputsystem
    private Vector3 velocity; // ��� �������
    private void Start()
    {
        characterController = GetComponent<CharacterController>(); // �������� ����������
    }

    private void Update()
    {
        velocity += Vector3.down * gravity * Time.deltaTime; // ��������� ���������
        if (characterController.isGrounded) // ���� �� �����
            velocity = Vector3.zero; // �������� ���������
        characterController.Move(velocity * Time.deltaTime); // ������ �� ����� � ����������

        // ������� ������ � ����������� ��������� ���������� � ���������� (����� ����� ���� ������������ ����� �� �������)
        Vector3 move = characterController.transform.TransformDirection(vector.x, 0f, vector.y); 
        move *= moveSpeed * Time.deltaTime; // ��������� ������ �� ��������
        characterController.Move(move); // ����������
    }

    public void OnMoveTrigger(InputAction.CallbackContext context)
    {
        vector = context.ReadValue<Vector2>(); // ������ vector2
    }
}
