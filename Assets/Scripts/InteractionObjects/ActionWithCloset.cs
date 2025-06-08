using UnityEngine;

public class ActionWithCloset : MonoBehaviour
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
            settingAnimations.ActiveAnimationBigCloset(true);
        }
    }

    public void ActivatorActionCloset(bool activator)
    {
        activatorAction = activator;
    }
}
