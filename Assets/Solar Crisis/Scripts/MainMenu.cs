using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float menuTimer;
    private float loadTime = 2.75f;
    private bool playGame = false;

    [SerializeField] private Animator logoAnimator;
    [SerializeField] private Animator sceneTransitionAnimator;
    [SerializeField] private GameObject sceneTransition;

    private void Update()
    {
        menuTimer += Time.deltaTime;

        if (menuTimer >= loadTime - 1f && playGame)
        {
            sceneTransition.SetActive(true);
            sceneTransitionAnimator.SetTrigger("End");
        }

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
        logoAnimator.SetBool("GameStart", true);
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
