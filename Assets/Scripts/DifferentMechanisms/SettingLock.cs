using UnityEngine;
using player.Inputs;
using CharacterController = player.Inputs.CharacterController;
using UnityEngine.UI;

public class SettingLock : MonoBehaviour
{
    [SerializeField] private GameObject menuCode;
    [SerializeField] private InputField textCode;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private MouseCamLook mouseCamLook;
    [SerializeField] private SettingAnimations settingAnimations;
    [SerializeField] private AudioSource audioOpen;
    [SerializeField] private AudioSource audioMistake;
    [SerializeField] private string correctCode;

    private BoxCollider boxCollider;

    private string ReceivedCode;
    private bool activeChecking;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        menuCode.SetActive(false);
        activeChecking = false;
    }

    private void Update()
    {
        if (activeChecking)
        {
            if (ReceivedCode == correctCode)
            {
                settingAnimations.ActiveAnimationObject(true);
                audioOpen.Play();
                boxCollider.enabled = false;
                ActiveMenuCode(false);
                activeChecking = false;
                UpdateData();
            }
            else
            {
                audioMistake.Play();
                activeChecking = false;
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            ActiveMenuCode(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            ActiveMenuCode(false);
        }
    }

    public void ReadTextCode()
    {
        ReceivedCode = textCode.text;
        activeChecking = true;
    }

    private void ActiveMenuCode(bool active)
    {
        if (active)
        {
            menuCode.SetActive(true);
            mouseCamLook.OnCursor();
        }
        else
        {
            menuCode.SetActive(false);
            mouseCamLook.OffCursor();
        }
    }

    private void UpdateData()
    {
        ReceivedCode = "";
        textCode.text = "";
    }
}
