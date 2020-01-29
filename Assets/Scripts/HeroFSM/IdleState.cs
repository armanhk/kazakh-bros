using System;

namespace HeroFSM
{
    public class IdleState : HeroState
    {
        public IdleState(Hero player) : base(player)
        {
            stateName = HeroStates.IDLE;
        }
    }

}
