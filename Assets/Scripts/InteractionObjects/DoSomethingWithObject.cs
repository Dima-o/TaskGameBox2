using UnityEngine;
using UnityEngine.UI;

public class DoSomethingWithObject : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectText;
    [SerializeField] private GameObject windowButtonF;
    [SerializeField] private GameObject Tool;
    [SerializeField] private GameObject buttonInBook;
    [SerializeField] private Text textHints;
    [SerializeField] private SettingButtons settingButtons;
    [SerializeField] private string textInteractingWithObject;

    private ActionWithCloset actionWithCloset;
    private DoorOpen doorOpen;
    private BoxCollider boxColliderObject;

    private bool isActiveTool;
    private bool activatorKeyF;

    private void Start()
    {
        actionWithCloset = gameObject.GetComponent<ActionWithCloset>();
        doorOpen = gameObject.GetComponent<DoorOpen>();
        boxColliderObject = GetComponent<BoxCollider>();
        
        gameObjectText.SetActive(false);
        windowButtonF.SetActive(false);
        activatorKeyF = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && activatorKeyF == true)
        {
            windowButtonF.SetActive(false);
            boxColliderObject.enabled = false;
            Tool.SetActive(false);

            if (actionWithCloset != null)
            {
                actionWithCloset.ActivatorActionCloset(true);
                DisableButtonInBook();
            }
                                                                             
            if (doorOpen != null)
            {
                doorOpen.ActivatorDoorOpen(true);
                DisableButtonInBook();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            textHints.text = textInteractingWithObject;
            isActiveTool = Tool.activeSelf;

            if (isActiveTool == false)
            {
                gameObjectText.SetActive(true);
            }
            else
            {
                windowButtonF.SetActive(true);
                activatorKeyF = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            gameObjectText.SetActive(false);
            windowButtonF.SetActive(false);
            activatorKeyF = false;
        }
    }

    private void DisableButtonInBook()
    {
        activatorKeyF = false;
        buttonInBook.SetActive(false);
    }
}
