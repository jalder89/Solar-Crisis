using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTypingState : PlayerState
{
    public PlayerTypingState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entering typing state");
        
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exiting typing state");
    }

    public override void Update()
    {
        base.Update();
    }
}
