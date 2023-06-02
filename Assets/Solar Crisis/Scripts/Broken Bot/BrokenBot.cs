using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class BrokenBot : MonoBehaviour
{
    private Canvas botUI;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        botUI = gameObject.GetComponentInChildren<Canvas>();
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
            botUI.enabled = !botUI.enabled;
            player.canType = true;
            player.trigger = gameObject.GetComponent<DialogueSystemTrigger>();
            Debug.Log("The player is in front of the broken bot");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            botUI.enabled = !botUI.enabled;
            player.canType = false;
            Debug.Log("The player has left the broken bot");
        }
    }
}
