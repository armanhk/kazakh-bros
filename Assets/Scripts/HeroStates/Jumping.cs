using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour, IState
{
    public Sprite StateSprite;
    public RuntimeAnimatorController StateAC;

    public void Enter(Hero hero, SpriteRenderer spriteRenderer, Animator animator)
    {
        // Set hero state to idle
        hero.state = StateEnum.ATTACKING;

        // Set animation and sprite
        spriteRenderer.sprite = StateSprite;
        animator.runtimeAnimatorController = StateAC;
    }

    IEnumerator Jump(Hero hero)
    {
        yield return new WaitForSeconds((float)0.45);

        hero.SetState(StateEnum.IDLE);
    }

    public void HandleInput(string input, Hero hero)
    {
        switch (input)
        {
            default:
                StartCoroutine(Jump(hero));
                break;
        }
    }

    public void UpdateState(Hero hero, SpriteRenderer spriteRenderer, Animator animator, string input = null)
    {
        if (hero.state != StateEnum.JUMPING)
        {
            Enter(hero, spriteRenderer, animator);
            hero.current.HandleInput(input, hero);
        }
    }
}
