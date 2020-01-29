using System;

namespace HeroFSM
{
    public enum HeroStates
    {
        IDLE,
        RUNNING,
    }

    public abstract class HeroState
    {
        protected Hero player;
        public HeroStates stateName;

        public HeroState(Hero player)
        {
            this.player = player;
        }

        public virtual void OnStateEnter()
        {
            player.heroRenderer.sprite = player.stateSprites[(int)stateName];
            player.heroAnimator.runtimeAnimatorController = player.stateControllers[(int)stateName];
        }

        public virtual void OnStateExit()
        {

        }
    }
}