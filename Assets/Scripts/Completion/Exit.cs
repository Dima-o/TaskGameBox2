using player.Inputs;
using UnityEngine;
using CharacterController = player.Inputs.CharacterController;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject menuCompletingGame;
    [SerializeField] private MouseCamLook mouseCamLook;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Loss loss;
    [SerializeField] private float timerExit;

    private bool activatorTimer;

    private void Start()
    {
        activatorTimer = false;
        menuCompletingGame.SetActive(false);
    }

    private void Update()
    {
        if (activatorTimer)
        {
            timerExit -= Time.deltaTime;

            if (timerExit < 0)
            {
                menuCompletingGame.SetActive(true);
                mouseCamLook.OnCursor();
                characterController.ActivatorMovement(false);
                loss.StopTimer();
            } 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            activatorTimer = true;
        }
    }
}
