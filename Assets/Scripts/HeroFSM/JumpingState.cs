﻿using UnityEngine;

namespace HeroFSM
{
    public class JumpingState : HeroState
    {

        public JumpingState(Hero player) : base(player)
        {
            this.stateSprite = player.jumpingSprite;
            this.stateAC = player.jumpingAC;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            player.isGrounded = false;

            Vector2 jump = new Vector2(0, player.jumpScalar);
            player.heroRigidbody.AddForce(jump);
        }

        public override void OnCollisionEnter(Collision2D collision)
        {
            base.OnCollisionEnter(collision);

            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > -5 && contact.normal.y < 5)
                {
                    player.isGrounded = true;
                }
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (player.isGrounded == true)
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