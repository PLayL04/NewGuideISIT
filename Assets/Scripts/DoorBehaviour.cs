using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IInteractable
{
    public Animator Animator;
    public bool isOpen;

    public void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        Animator.SetBool("isOpenDoor1", isOpen);
        isOpen = !isOpen;
    }
    /*
     * ”ниверсальный комментарий
     */
}
