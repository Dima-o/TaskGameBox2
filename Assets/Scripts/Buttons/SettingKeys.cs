using UnityEngine;
using player.Inputs;

public class SettingKeys : MonoBehaviour
{
    [SerializeField] private GameObject menuBook;
    [SerializeField] private GameObject menyPause;
    [SerializeField] private MouseCamLook mouseCamLook;

    private bool activeMenuBook;
    private bool activeMenuPause;

    private void Start()
    {
        menuBook.SetActive(false);
        menyPause.SetActive(false);
        activeMenuBook = false;
        activeMenuPause = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            BookMode();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMode();
        }
    }

    private void BookMode()
    {
        activeMenuBook = !activeMenuBook;

        if (activeMenuBook)
        {
            mouseCamLook.OnCursor();
            menuBook.SetActive(true);
        }
        else
        {
            mouseCamLook.OffCursor();
            menuBook.SetActive(false);
        }
    }

    public void PauseMode()
    {
        activeMenuPause = !activeMenuPause;

        if (activeMenuPause)
        {
            menyPause.SetActive(true);
            mouseCamLook.OnCursor();
            Time.timeScale = 0;
        }
        else
        {
            menyPause.SetActive(false);
            mouseCamLook.OffCursor();
            Time.timeScale = 1;
        }
    }
}
