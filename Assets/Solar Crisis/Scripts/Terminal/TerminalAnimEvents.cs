using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalAnimEvents : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void BootComplete()
    {
        player.stateMachine.ChangeState(player.idleState);
    }
}
