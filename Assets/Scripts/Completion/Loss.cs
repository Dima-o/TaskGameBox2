using player.Inputs;
using UnityEngine;
using UnityEngine.UI;
using CharacterController = player.Inputs.CharacterController;

public class Loss : MonoBehaviour
{
    [SerializeField] private Text textTimer;
    [SerializeField] private GameObject menuLoss;
    [SerializeField] private MouseCamLook mouseCamLook;
    [SerializeField] private float timerInMinutes;

    private CharacterController characterController;

    private float timer;
    private bool activeTimer;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        timer = timerInMinutes * 60;
        menuLoss.SetActive(false);
        activeTimer = true;
    }

    void Update()
    {
        if (timer > 0)
        {
            if (activeTimer)
            {
                timer -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(timer / 60);
                float seconds = Mathf.FloorToInt(timer % 60);
                textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
        else
        {
            mouseCamLook.OnCursor();
            ResetTimer();
            menuLoss.SetActive(true);
            characterController.ActivatorMovement(false);
        }
    }

    private void ResetTimer()
    {
        textTimer.text = "";
        timer = 0;
    }

    public void StopTimer()
    {
        activeTimer = false;
    }
}
