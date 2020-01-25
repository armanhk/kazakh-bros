using System;
using UnityEngine;

public class Idle : MonoBehaviour, IState
{
    public Sprite StateSprite;
    public RuntimeAnimatorController StateAC;

    public void Enter(Hero hero, SpriteRenderer spriteRenderer, Animator animator)
    {
        // Set hero state to idle
        hero.state = StateEnum.IDLE;

        // Set animation and sprite
        spriteRenderer.sprite = StateSprite;
        animator.runtimeAnimatorController = StateAC;
    }

    public void HandleInput(string input, Hero hero)
    {
        switch (input)
        {
            default:
                break;
        }
    }

    public void UpdateState(Hero hero, SpriteRenderer spriteRenderer, Animator animator, string input = null)
    {
        Enter(hero, spriteRenderer, animator);
        hero.current.HandleInput(input, hero);
    }
}
