using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButtons : MonoBehaviour
{
    [SerializeField] private GameObject[] tools;
    [SerializeField] private SettingKeys settingKeys;

    private AudioSource audioSource;
    private bool activebTools;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        activebTools = false;
    }

    public void ActivatingObjectsInAaCharacter(int numberCall)
    {
        audioSource.Play();
        activebTools = !activebTools;

        if (activebTools)
        {
            tools[numberCall].SetActive(true);

            for (int i = 0; i < tools.Length; i++)
            {
                if (i != numberCall)
                {
                    tools[i].SetActive(false);
                }
            }
        }
        else
        {
            tools[numberCall].SetActive(false);
        }
    }

    public void ButtonPlay()
    {
        audioSource.Play();
        StartCoroutine(LoadNextSceneAfterTime(0.1f, 1));
    }

    public void ButtonInstruction()
    {
        audioSource.Play();
        StartCoroutine(LoadNextSceneAfterTime(0.1f, 2));
    }

    public void ButtonExit()
    {
        audioSource.Play();
        StartCoroutine(ExitTheGame(0.1f));
    }

    public void ButtonInMenu()
    {
        audioSource.Play();
        Time.timeScale = 1;
        StartCoroutine(LoadNextSceneAfterTime(0.1f, 0));
    }

    public void ButtonContinue()
    {
        audioSource.Play();
        settingKeys.PauseMode();
    }

    IEnumerator LoadNextSceneAfterTime(float time, int index)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(index);
    }

    IEnumerator ExitTheGame(float time)
    {
        yield return new WaitForSeconds(time);
        Application.Quit();
    }

    IEnumerator ContinueGame(float time)
    {
        yield return new WaitForSeconds(time);
        settingKeys.PauseMode();
    }
}
