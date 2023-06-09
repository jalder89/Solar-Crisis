using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class BrokenBot : MonoBehaviour
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Broken Bot Start");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.canType = true;
            player.trigger = gameObject.GetComponent<DialogueSystemTrigger>();
            Debug.Log("The player is in front of the broken bot");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.canType = false;
            Debug.Log("The player has left the broken bot");
        }
    }
}
