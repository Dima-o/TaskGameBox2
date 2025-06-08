using UnityEngine;

public class SettingAnimations : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActiveAnimationObject(bool active)
    {
        animator.SetBool("activeObjectMovement", active);
    }

    public void ActiveAnimationBigCloset(bool active)
    {
        animator.SetBool("activatorFallingBigClosed", active);
    }

    public void ActiveAnimationDoorOpen(bool active)
    {
        animator.SetBool("activeDoorOpen", active);
    }

    public void ActiveAnimationDoubleDoorOpen(bool active)
    {
        animator.SetBool("activeOpenDoor", active);
    }
}
