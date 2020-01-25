using System;
using UnityEngine;

public interface IState
{
    void Enter(Hero hero, SpriteRenderer spriteRenderer, Animator animator);
    void HandleInput(string input, Hero hero);
    void UpdateState(Hero hero, SpriteRenderer spriteRenderer, Animator animator, string input = null);
}
