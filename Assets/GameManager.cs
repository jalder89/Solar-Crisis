using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform firstSpawn;

    private CinemachineVirtualCamera vcam;
    private string previousSceneName;
    private Player playerScript;

    private void Awake()
    {
        Debug.Log("Game Manager Awake");
        DontDestroyOnLoad(this.gameObject);
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
        if(scene.name != "Start" || scene.name != "ShipCockpit")
        {
            ManagePlayerSpawn();
        }

        GetPlayer();
        vcam = GameObject.FindGameObjectWithTag("VirtualCam").GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = player.transform;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        previousSceneName = scene.name;
    }

    #region Player Spawning
    private void ManagePlayerSpawn()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(player);
            GetPlayer();
            ManagePlayerInitialTransform();
        }

        
    }

    private void GetPlayer()
    {
        Debug.Log("Getting Player in Game Manager");
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    private void ManagePlayerInitialTransform()
    {
        Debug.Log("Adjusting position and rotation");
        player.transform.position = firstSpawn.position;
        player.transform.Rotate(0, 180, 0);
    }
    #endregion
}