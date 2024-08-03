using System;
using System.Collections.Generic;
using Utils;

namespace Platformer
{
    class InitState : IState
    {
        private readonly StateMachine stateMachine;
        private readonly Input input;
        private readonly PlayerSpawner playerSpawner;
        private readonly EnemySpawner[] enemySpawners;

        public InitState(StateMachine stateMachine, Input input, PlayerSpawner playerSpawner, EnemySpawner[] enemySpawners)
        {
            this.stateMachine = stateMachine;
            this.input = input;
            this.playerSpawner = playerSpawner;
            this.enemySpawners = enemySpawners;
        }

        public void OnEnter()
        {
            //init servises
            playerSpawner.Init(input);
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].Init();
            }

            stateMachine.EnterState<GameplayState>();
        }

        public void OnExit()
        {
        }
    }
}
