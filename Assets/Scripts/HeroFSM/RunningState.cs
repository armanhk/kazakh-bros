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

            // Start the velocity drop before exiting run state
            if (Input.GetButtonUp("Horizontal"))
            {
                player.StartCoroutine(VelocityDrop());
            }
        }


        /// <summary>
        /// To be used as coroutine to exit running state
        /// </summary>
        /// <returns>wait until velocity magnitude drops by 1</returns>
        IEnumerator VelocityDrop()
        {
            float magnitude = player.heroRigidbody.velocity.magnitude;
            if (magnitude > 1)
            {
                yield return new WaitUntil(() => player.heroRigidbody.velocity.magnitude < magnitude - 1);
            }

            // Set state to idle
            player.heroRigidbody.velocity = Vector2.zero;
            player.SetState(player.idleState);
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

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}
