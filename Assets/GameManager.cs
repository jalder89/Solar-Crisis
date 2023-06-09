using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private string previousSceneName;
    private Player playerScript;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Previous scene name: " + previousSceneName);
        GetPlayer();
        ManagePlayerSpawn();
    }

    private void OnSceneUnloaded(Scene scene)
    {
        previousSceneName = scene.name;
    }

    private void GetPlayer()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    #region Player Spawning
    private void ManagePlayerSpawn()
    {
        ManagePlayerSpawnDirection();
    }

    private void ManagePlayerSpawnDirection()
    {
        Debug.Log("Checking rotation");
        if (player.transform.rotation.y == 1 || player.transform.rotation.y == -1)
        {
            Debug.Log("Correcting");
            playerScript.facingDir = -1;
            playerScript.facingRight = false;
        }
    }
    #endregion
}