using System;

namespace HeroFSM
{
    public class IdleState : HeroState
    {
        public IdleState(Hero player) : base(player)
        {
            this.stateSprite = player.idleSprite;
            this.stateAC = player.idleAC;
        }
    }

}
