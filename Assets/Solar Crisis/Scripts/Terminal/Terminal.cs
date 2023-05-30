using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        player = GameObject.Find("Player").GetComponent<Player>();
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
            terminalUI.enabled = !terminalUI.enabled;
            player.isAtComputer = true;
            Debug.Log("The player is in front of the terminal");

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
            terminalUI.enabled = !terminalUI.enabled;
            player.isAtComputer = false;
            player.canType = false;
            player.canInteract = false;
            Debug.Log("The player has left the terminal");
        }
    }
}