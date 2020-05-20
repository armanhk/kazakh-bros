using UnityEngine;

namespace HeroFSM
{
    public class SecondaryAttackState : HeroState
    {
        public SecondaryAttackState(Hero player) : base(player)
        {
            this.stateSprite = player.secondaryAttackSprite;
            this.stateAC = player.secondaryAttackAC;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            // Exit attack after last sprite in animation
            if (player.heroRenderer.sprite.name == "Attack2_3")
            {
                if (player.stateStack.Peek() != player.idleState)
                {
                    player.stateStack.Pop();
                }
            }
        }
    }
}