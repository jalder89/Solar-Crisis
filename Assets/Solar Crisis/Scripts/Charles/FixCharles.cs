using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCharles : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private Animator imageAnimator;
    [SerializeField] private GameObject brokenCharles;
    [SerializeField] private GameObject charles;

    private float timer;
    private bool fixCharles;

    private void Update()
    {
        timer += Time.deltaTime;

        if (fixCharles && timer >= 1)
        {
            brokenCharles.SetActive(false);
            charles.SetActive(true);
            imageAnimator.SetTrigger("Start");
        }

        if (fixCharles && timer >= 2f)
        {
            fixCharles = false;
            image.SetActive(false);
        }
    }

    public void SetTimer()
    {
        timer = 0;
    }

    public void FixCharlesBot()
    {
        SetTimer();
        fixCharles = true;
    }
}
