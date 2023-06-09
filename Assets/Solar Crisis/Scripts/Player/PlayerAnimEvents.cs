using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class PlayerAnimEvents : MonoBehaviour
{
    private Player player;
    private Animator anim;
    public Terminal terminal;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = player.anim;
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
            anim.SetBool("Interact", false);
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
        anim.SetBool("IdleLong", false);
        anim.SetBool("Idle", true);
        player.idleTimer = 0;
    }
}
