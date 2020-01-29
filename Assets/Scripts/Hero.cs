using UnityEngine;
using HeroFSM;

public class Hero : MonoBehaviour
{
    // UnityEngine members (attach assets and components to these)
    public SpriteRenderer heroRenderer;
    public Animator heroAnimator;
    public Sprite[] stateSprites;
    public RuntimeAnimatorController[] stateControllers;

    // State members
    public HeroState currentState;
    static IdleState idleState;

    public void SetState(HeroState state)
    {
        if (currentState != null)
        {
            // TODO: Add call to OnStateExit here if we need it
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

        SetState(idleState);
    }

    public void Update()
    {
        
    }

    #endregion
}
