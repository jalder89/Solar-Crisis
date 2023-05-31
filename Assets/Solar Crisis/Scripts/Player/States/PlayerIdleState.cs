using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{

    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("IdleLong", false);
        player.idleTimer = 0;
    }

    public override void Update()
    {
        base.Update();
        player.idleTimer += Time.deltaTime;

        if (xInput != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }

        if (Input.GetButtonDown("Interact") && player.canInteract)
        {
            stateMachine.ChangeState(player.interactState);
        }

        if (Input.GetButtonDown("Interact") && player.canType)
        {
            stateMachine.ChangeState(player.typingState);
        }

        // Needs long idle state for proper control
        if (player.idleTimer >= 15)
        {
            player.anim.SetBool("Idle", false);
            player.anim.SetBool("IdleLong", true);
        }
    }
}
