﻿using UnityEngine;
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
    public Sprite primaryAttackSprite;
    public Sprite secondaryAttackSprite;

    // State animator controllers
    public RuntimeAnimatorController idleAC;
    public RuntimeAnimatorController runningAC;
    public RuntimeAnimatorController jumpingAC;
    public RuntimeAnimatorController primaryAttackAC;
    public RuntimeAnimatorController secondaryAttackAC;

    // States
    internal IdleState idleState;
    internal RunningState runningState;
    internal JumpingState jumpingState;
    internal PrimaryAttackState primaryAttackState;
    internal SecondaryAttackState secondaryAttackState;

    public HeroState currentState;
    public HeroStack<HeroState> stateStack;

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

    public void Reset()
    {
        this.transform.position = new Vector3(-118, -45, this.transform.position.z);
    }

    #region Game Loop

    public void Start()
    {
        // Instantiate static states
        idleState = new IdleState(this);
        runningState = new RunningState(this);
        jumpingState = new JumpingState(this);
        primaryAttackState = new PrimaryAttackState(this);
        secondaryAttackState = new SecondaryAttackState(this);

        stateStack = new HeroStack<HeroState>(this);
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
        }

        if (Input.GetButtonDown("Jump") &&
            currentState != jumpingState)
        {
            stateStack.Push(jumpingState);
        }

        if (Input.GetMouseButtonDown(0) &&
            currentState != primaryAttackState &&
            currentState != jumpingState)
        {
            stateStack.Push(primaryAttackState);
        }

        if (Input.GetMouseButtonDown(1) &&
            currentState != secondaryAttackState &&
            currentState != jumpingState)
        {
            stateStack.Push(secondaryAttackState);
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
