using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalAnimEvents : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void ComputerHum()
    {
        audioSource.Play();
    }

    public void BootComplete()
    {
        player.stateMachine.ChangeState(player.idleState);
    }
}
