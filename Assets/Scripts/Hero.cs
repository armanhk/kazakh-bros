using UnityEngine;
using HeroFSM;

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

    public HeroState currentState;

    public float maxSpeed;
    public float movementScalar;


    #endregion

    public void SetState(HeroState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = state;

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

        SetState(idleState);
    }

    public void Update()
    {
        currentState.OnUpdate();

        if (Input.GetButtonDown("Horizontal") && currentState != runningState)
        {
            SetState(runningState);
        }

        
    }

    public void FixedUpdate()
    {
        currentState.OnFixedUpdate();
    }

    #endregion
}
