using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Terminal : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;

    private Canvas terminalUI;
    private Player player;
    public Animator anim;
    public bool isPowerOn;


    // Start is called before the first frame update
    void Start()
    {
        terminalUI = gameObject.GetComponentInChildren<Canvas>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = gameObject.GetComponentInChildren<Animator>();
        isPowerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // terminalUI.enabled = !terminalUI.enabled;
            player.isAtComputer = true;
            player.trigger = gameObject.GetComponent<DialogueSystemTrigger>();

            if (isPowerOn)
            {
                player.canInteract = false;
                player.canType = true;
            }
            else
            {
                player.canType = false;
                player.canInteract = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // terminalUI.enabled = !terminalUI.enabled;
            player.isAtComputer = false;
            player.canType = false;
            player.canInteract = false;
        }
    }

    public void TurnOn()
    {
        audioSource.PlayOneShot(audioSource.clip);
        anim.SetBool("PowerOn", true);
    }
}
