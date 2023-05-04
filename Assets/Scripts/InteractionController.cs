using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public void OnInteractionTrigger(InputAction.CallbackContext context)
    {
        Debug.Log($"Взаимодействие: состояние {context.phase}");
    }
}
