using System;
using System.Collections;
using UnityEngine;

public class Attacking : MonoBehaviour, IState
{
    public Sprite StateSprite;
    public RuntimeAnimatorController StateAC;

    /// <summary>
    /// Enter this state
    /// </summary>
    /// <param name="hero"></param>
    /// <param name="spriteRenderer"></param>
    /// <param name="animator"></param>
    public void Enter(Hero hero, SpriteRenderer spriteRenderer, Animator animator)
    {
        // Set hero state to idle
        hero.state = StateEnum.ATTACKING;

        // Set animation and sprite
        spriteRenderer.sprite = StateSprite;
        animator.runtimeAnimatorController = StateAC;
    }

    /// <summary>
    /// Coroutine helper - one attack animation
    /// </summary>
    /// <param name="hero">hero to animate</param>
    /// <returns>IEnumerator for coroutine</returns>
    IEnumerator Attack(Hero hero)
    {
        yield return new WaitForSeconds((float)0.25);

        hero.SetState(StateEnum.IDLE);
    }

    /// <summary>
    /// Start the Attack coroutine by default
    /// </summary>
    /// <param name="input">can be used for different attacks</param>
    /// <param name="hero">hero to animate</param>
    public void HandleInput(string input, Hero hero)
    {
        switch (input)
        {
            default:
                StartCoroutine(Attack(hero));
                break;
        }
    }

    /// <summary>
    /// Updates the hero with the attack state
    /// </summary>
    /// <param name="hero"></param>
    /// <param name="spriteRenderer"></param>
    /// <param name="animator"></param>
    /// <param name="input"></param>
    public void UpdateState(Hero hero, SpriteRenderer spriteRenderer, Animator animator, string input = null)
    {
        if (hero.state != StateEnum.ATTACKING)
        {
            Enter(hero, spriteRenderer, animator);
            hero.current.HandleInput(input, hero);
        }
    }
}
