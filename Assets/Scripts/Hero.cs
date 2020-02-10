using UnityEngine;
using HeroFSM;
using System.Collections.Generic;

public class Hero : MonoBehaviour
{
    #region Members

    // Setting hero
    public SpriteRenderer heroRenderer;
    public Animator heroAnimator;
    public Rigidbody2D heroRigidbody;

    // State sprites
    public Sprite idleSprite;
    public Sprite runningSprite;
    public Sprite jumpingSprite;
    public Sprite fallingSprite;

    // State animator controllers
    public RuntimeAnimatorController idleAC;
    public RuntimeAnimatorController runningAC;
    public RuntimeAnimatorController jumpingAC;

    // States
    internal IdleState idleState;
    internal RunningState runningState;
    internal JumpingState jumpingState;

    public HeroState currentState;
    public Stack<HeroState> stateStack;

    public float maxSpeed;
    public float movementScalar;
    public float jumpScalar;

    public bool isGrounded;

    #endregion

    public void TryTransition()
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = stateStack.Peek();

        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }

    #region Game Loop

    public void Start()
    {
        // Instantiate static states
        idleState = new IdleState(this);
        runningState = new RunningState(this);
        jumpingState = new JumpingState(this);

        stateStack = new Stack<HeroState>();
        stateStack.Push(idleState);
        TryTransition();
    }

    public void Update()
    {
        currentState.OnUpdate();

        if (Input.GetButtonDown("Horizontal") &&
            stateStack.Contains(runningState) != true &&
            currentState != jumpingState)
        {
            stateStack.Push(runningState);
            TryTransition();
        }

        if (Input.GetKeyDown(KeyCode.Space) &&
            stateStack.Peek() != jumpingState)
        {
            stateStack.Push(jumpingState);
            TryTransition();
        }
    }

    public void FixedUpdate()
    {
        currentState.OnFixedUpdate();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(collision);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(collision);
    }

    #endregion
}
