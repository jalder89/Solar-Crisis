using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class PlayerAnimEvents : MonoBehaviour
{
    private Player player;
    public Terminal terminal;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    public void TypingComplete()
    {
        player.stateMachine.ChangeState(player.idleState);
    }

    public void InteractComplete()
    {
        if (player.isAtComputer)
        {
            terminal.isPowerOn = true;
            player.canType = true;
            player.canInteract = false;
            // terminal.anim.SetBool("PowerOn", true);
            player.anim.SetBool("Interact", false);
            player.stateMachine.ChangeState(player.idleState);
        } else
        {
            player.stateMachine.ChangeState(player.idleState);
        }
    }

    public void ButtonClick()
    {
        if (player.isAtComputer)
        {
            terminal.audioSource.PlayOneShot(terminal.audioSource.clip);
        }
    }

    public void CleanGlassesEnd()
    {
        player.anim.SetBool("IdleLong", false);
        player.anim.SetBool("Idle", true);
        player.idleTimer = 0;
    }
}
