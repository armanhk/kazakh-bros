using System.Collections;
using UnityEngine;

namespace HeroFSM
{
    public class PrimaryAttackState : HeroState
    {
        public PrimaryAttackState(Hero player) : base(player)
        {
            this.stateSprite = player.primaryAttackSprite;
            this.stateAC = player.primaryAttackAC;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            // Exit attack after last sprite in animation
            if (player.heroRenderer.sprite.name == "Attack1_3")
            {
                if (player.stateStack.Peek() != player.idleState)
                {
                    player.stateStack.Pop();
                    player.TryTransition();
                }
            }
        }
    }
}
