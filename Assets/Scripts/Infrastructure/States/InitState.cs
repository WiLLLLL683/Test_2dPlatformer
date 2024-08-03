using System;
using System.Collections.Generic;
using Utils;

namespace Platformer
{
    class InitState : IState
    {
        private readonly StateMachine stateMachine;
        public InitState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            //init servises

            stateMachine.EnterState<GameplayState>();
        }

        public void OnExit()
        {
        }
    }
}
