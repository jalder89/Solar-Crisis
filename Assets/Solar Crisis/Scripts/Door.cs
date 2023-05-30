using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Canvas doorUI;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        doorUI = gameObject.GetComponentInChildren<Canvas>();
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
            doorUI.enabled = !doorUI.enabled;
            player.canInteract = true;
            Debug.Log("The player is in front of the door");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            doorUI.enabled = !doorUI.enabled;
            player.canInteract = true;
            Debug.Log("The player has left the door");
        }
    }
}
