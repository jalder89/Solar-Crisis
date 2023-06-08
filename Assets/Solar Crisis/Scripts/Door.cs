using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;
using System.Runtime.InteropServices;

public class Door : MonoBehaviour
{
    [SerializeField] Object sceneToLoad;
    [SerializeField] private GameObject image;
    [SerializeField] private Animator imageAnimator;

    private Player player;
    private float timer;
    private bool transition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (transition && timer >= 1)
        {
            EnterDoor();
        }
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
        transition = false;
        SceneManager.LoadSceneAsync(sceneToLoad.name);
    }

    public void Transition()
    {
        transition = true;
        timer = 0;
        image.SetActive(true);
        imageAnimator.SetTrigger("End");
    }
}
