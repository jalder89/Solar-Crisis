using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [Header("Move Info")]
    public float moveSpeed;
    public float velocity;

    public int facingDir { get; set; } = 1;
    public bool facingRight = true;

    public bool canType = false;
    public bool canInteract = false;
    public bool isAtComputer = false;
    public DialogueSystemTrigger trigger;

    public float idleTimer;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerMoveState moveLeftState { get; private set; }
    public PlayerInteractState interactState { get; private set; }
    public PlayerTypingState typingState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        DontDestroyOnLoad(this.gameObject);
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        moveLeftState = new PlayerMoveState(this, stateMachine, "Move");
        interactState = new PlayerInteractState(this, stateMachine, "Interact");
        typingState = new PlayerTypingState(this, stateMachine, "Typing");
    }

    private void OnEnable()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;        
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        idleTimer = 0;

        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        //FlipController(_xVelocity);
    }

    //public void Flip()
    //{
    //    facingDir = facingDir * -1;
    //    facingRight = !facingRight;
    //    transform.Rotate(0, 180, 0);
    //}

    //public void FlipController(float _x)
    //{
    //    if (_x > 0 && !facingRight)
    //    {
    //        Flip();
    //    }
    //    else if (_x < 0 && facingRight)
    //    {
    //        Flip();
    //    }
    //}

    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    if (transform.rotation.y == 1 || transform.rotation.y == -1)
    //    {
    //        Debug.Log("Correcting Left Face");
    //        facingDir = -1;
    //        facingRight = false;
    //    }
    //}
}
