using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float menuTimer;
    private float loadTime = 1.6f;
    private bool playGame = false;

    private void Update()
    {
        menuTimer += Time.deltaTime;

        if (menuTimer >= loadTime && playGame)
        {
            menuTimer = 0;
            LoadScene();
        }
    }

    public void PlayGame()
    {
        menuTimer = 0;
        playGame = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void LoadScene()
    {
        SceneManager.LoadSceneAsync("EntryHall");
    }
}
