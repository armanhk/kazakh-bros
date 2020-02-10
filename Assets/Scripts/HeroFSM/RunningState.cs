using System.Collections;
using UnityEngine;

namespace HeroFSM
{
    public class RunningState : HeroState
    {
        public RunningState(Hero player) : base(player)
        {
            this.stateSprite = player.runningSprite;
            this.stateAC = player.runningAC;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            float axis = Input.GetAxis("Horizontal");

            // Direction
            if (axis < 0)
            {
                player.heroRenderer.flipX = true;
            }
            else if (axis > 0)
            {
                player.heroRenderer.flipX = false;
            }

            // Release button - player stops
            if (Input.GetButton("Horizontal") != true)
            {
                player.heroRigidbody.velocity = Vector2.zero;
                if (player.stateStack.Peek() != player.idleState)
                {
                    player.stateStack.Pop();
                }
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            float direction = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(direction * player.movementScalar, 0);

            // Accelerate if player's velocity.magnitude < maxSpeed
            if (player.heroRigidbody.velocity.magnitude < player.maxSpeed)
            {
                player.heroRigidbody.AddForce(movement);
            }
        }
    }
}
