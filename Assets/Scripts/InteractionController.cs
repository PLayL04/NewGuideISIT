using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public Camera camera;
    public float interactionDistance = 5f;

    public void Start()
    {
        camera = Camera.main;
    }

    public void OnInteractionTrigger(InputAction.CallbackContext input)
    {
        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance) && input.phase == InputActionPhase.Started)
        {
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
                Debug.Log("Взаимодействие");
            }
            else
            {
                Debug.Log("Не с чем взаимодейсвовать");
            }
        }
    }
    /*
     * Метод OnInteractionTrigger() вызывается при нажатии на определенную кнопку
     * на клавиатуре или контроллере игрока. Внутри метода происходит создание луча
     * из центра камеры в направлении экрана, который проверяет, есть ли объекты в 
     * зоне взаимодействия (interactionDistance) и если нажата кнопка для начала 
     * взаимодействия (InputActionPhase.Started). Если объект найден и он имеет компонент 
     * IInteractable, то вызывается метод Interact() у этого объекта. Если же объект не
     * найден или не имеет нужного компонента, то выводится соответствующее сообщение в консоль.
     */
}