using System.Collections.Generic;
using UnityEngine;

namespace HeroFSM
{
    public class HeroStack<HeroState> : Stack<HeroState>
    {
        private Hero player;

        public HeroStack(Hero player)
        {
            this.player = player;
        }

        public void TryTransition()
        {
            if (player.currentState != null)
            {
                player.currentState.OnStateExit();
            }

            player.currentState = player.stateStack.Peek();

            if (player.currentState != null)
            {
                player.currentState.OnStateEnter();
            }
        }

        public new void Push(HeroState state)
        {
            base.Push(state);

            TryTransition();
        }

        public new void Pop()
        {
            base.Pop();

            TryTransition();
        }
    }
}
