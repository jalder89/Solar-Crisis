using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class Door : MonoBehaviour
{
    [SerializeField] Variable sceneToLoad;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
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
            player.trigger = gameObject.GetComponent<DialogueSystemTrigger>();
            player.canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.canInteract = true;
        }
    }

    public void EnterDoor()
    {
        SceneManager.LoadScene(sceneToLoad.Name, LoadSceneMode.Single);
    }
}
