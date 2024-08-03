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
        private readonly ItemSpawner itemSpawner;

        public InitState(StateMachine stateMachine, Input input, PlayerSpawner playerSpawner, EnemySpawner[] enemySpawners, ItemSpawner itemSpawner)
        {
            this.stateMachine = stateMachine;
            this.input = input;
            this.playerSpawner = playerSpawner;
            this.enemySpawners = enemySpawners;
            this.itemSpawner = itemSpawner;
        }

        public void OnEnter()
        {
            //init servises
            playerSpawner.Init(input);
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].Init(itemSpawner);
            }

            stateMachine.EnterState<GameplayState>();
        }

        public void OnExit()
        {
        }

        public void OnUpdate()
        {

        }
    }
}
