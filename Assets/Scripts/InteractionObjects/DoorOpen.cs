using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private SettingAnimations settingAnimations;
    private bool activatorAction;

    private void Start()
    {
        activatorAction = false;
        settingAnimations = GetComponent<SettingAnimations>();
    }

    private void Update()
    {
        if (activatorAction)
        {
            settingAnimations.ActiveAnimationDoorOpen(true);
        }
    }

    public void ActivatorDoorOpen(bool activator)
    {
        activatorAction = activator;
    }
}
