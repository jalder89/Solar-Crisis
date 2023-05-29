using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBotAnimEvents : MonoBehaviour
{
    [SerializeField] private AudioSource sparkSound;
    [SerializeField] private Animator anim;

    private float animTimer = 0;
    private int waitTime = 0;

    private void Start()
    {
        RandomizeDelay();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        animTimer += Time.deltaTime;

        if (animTimer >= waitTime)
        {
            animTimer = 0;
            SparkSoundEvent();
            anim.SetBool("Spark", true);
            RandomizeDelay();
        }
    }

    private void SparkSoundEvent()
    {
        sparkSound.PlayOneShot(sparkSound.clip);
    }

    private void SparkEndAnimEvent()
    {
        anim.SetBool("Spark", false);
    }

    private void RandomizeDelay()
    {
        waitTime = Random.Range(8, 13);
    }
}
