using player.Inputs;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExitGame : MonoBehaviour
{
    [SerializeField] private GameObject windowButtonF;
    [SerializeField] private MouseCamLook mouseCamLook;

    private bool activatorKeyF;

    private void Start()
    {
        windowButtonF.SetActive(false);
        activatorKeyF = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && activatorKeyF == true)
        {
            mouseCamLook.OnCursor();
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            windowButtonF.SetActive(true);
            activatorKeyF = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            windowButtonF.SetActive(false);
            activatorKeyF = false;
        }
    }
}
