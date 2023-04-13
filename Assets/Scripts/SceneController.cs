using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TMP_Text roomCode;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        if (pauseMenu)
            pauseMenu.SetActive(false);
    }

    public void TogglePause()
    {
        if (pauseMenu == null)
            return;

        if (!isPaused)
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        if (isPaused)
            TogglePause();

        SceneManager.LoadScene(sceneIndex);
    }

    public void JoinGame(int sceneIndex)
    {
        if (roomCode.text != "")
            ChangeScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ButtonSound()
    {
        AudioManager.instance.Play("Button");
    }

}
