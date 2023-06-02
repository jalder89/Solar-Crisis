using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : PlayerState
{
    public PlayerInteractState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.trigger.OnUse();
        Debug.Log("Entering interaction state");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exiting interaction state");
    }

    public override void Update()
    {
        base.Update();
    }

    public void Test()
    {

    }
}
