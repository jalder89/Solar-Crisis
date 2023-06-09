using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumBot : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed = 200;
    [SerializeField] private int killSpeed = 400;
    [SerializeField] private Collider2D botCollider;
    [SerializeField] private AudioSource attackScare;
    [SerializeField] private AudioSource killScare;
    [SerializeField] private GameObject image;
    [SerializeField] private Animator imageAnimator;
    [SerializeField] private GameObject gameOverCanvas;


    private bool searching = false;
    private bool killing = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (searching)
        {
            Move();
        }

        if (killing)
        {
            MoveFast();
        }
    }


    public void Search()
    {
        botCollider.isTrigger = false;
        rb.gravityScale = 3;
        searching = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (searching)
        {
            searching = false;
            killing = true;
            anim.SetTrigger("Kill");
            attackScare.PlayOneShot(attackScare.clip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // image.SetActive(true);
            // imageAnimator.SetTrigger("Cut");
            // gameOverCanvas.SetActive(true);
            killScare.PlayOneShot(killScare.clip);
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveSpeed * Time.deltaTime, 0);
    }

    private void MoveFast()
    {
        rb.velocity = new Vector2(killSpeed * Time.deltaTime, 0);
    }
}
