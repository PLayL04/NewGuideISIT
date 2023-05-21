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
}