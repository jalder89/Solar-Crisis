using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimEvents : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private Animator sceneTransitionAnim;
    [SerializeField] private GameObject transitionImage;

    public void LogoDisolved()
    {
        logo.SetActive(false);
    }

    public void FadeOut()
    {
        transitionImage.SetActive(true);
        sceneTransitionAnim.SetTrigger("End");
    }
}
