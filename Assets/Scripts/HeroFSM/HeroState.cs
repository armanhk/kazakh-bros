using System;
using UnityEngine;

namespace HeroFSM
{
    public abstract class HeroState
    {
        protected Hero player;
        protected Sprite stateSprite;
        protected RuntimeAnimatorController stateAC;

        public HeroState(Hero player)
        {
            this.player = player;
        }

        public virtual void OnStateEnter()
        {
            player.heroRenderer.sprite = this.stateSprite;
            player.heroAnimator.runtimeAnimatorController = this.stateAC;
        }

        public virtual void OnStateExit()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnCollisionEnter(Collision2D collision)
        {

        }

        public virtual void OnCollisionExit(Collision2D collision)
        {

        }
    }
}