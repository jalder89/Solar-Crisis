using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    private Animator anim;
    private Player player;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    public void TypingComplete()
    {
        anim.SetBool("Typing", false);
        player.stateMachine.ChangeState(player.idleState);
    }
}
