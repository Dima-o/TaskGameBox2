using UnityEngine;

public class DoubleAlienDoors : MonoBehaviour
{
    private SettingAnimations settingAnimations;
    private BoxCollider boxCollider;

    private void Start()
    {
        settingAnimations = GetComponent<SettingAnimations>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            settingAnimations.ActiveAnimationDoubleDoorOpen(true);
            boxCollider.enabled = true;
        }
    }
}
