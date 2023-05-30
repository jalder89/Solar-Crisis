using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    private Canvas terminalUI;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        terminalUI = gameObject.GetComponentInChildren<Canvas>();
        player = GameObject.Find("Player").GetComponent<Player>();
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
            player.canType = true;
            Debug.Log("The player is in front of the terminal");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            terminalUI.enabled = !terminalUI.enabled;
            player.canType = false;
            Debug.Log("The player has left the terminal");
        }
    }
}
