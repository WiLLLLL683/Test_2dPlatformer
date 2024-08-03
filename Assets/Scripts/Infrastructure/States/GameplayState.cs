using System;
using Utils;

namespace Platformer
{
    class GameplayState : IState
    {
        private readonly Input input;
        private readonly PlayerSpawner playerSpawner;
        private readonly EnemySpawner[] enemySpawners;

        public GameplayState(Input input, PlayerSpawner playerSpawner, EnemySpawner[] enemySpawners)
        {
            this.input = input;
            this.playerSpawner = playerSpawner;
            this.enemySpawners = enemySpawners;
        }

        public void OnEnter()
        {
            input.Enable();
            playerSpawner.Spawn();
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].Spawn();
            }
        }

        public void OnExit()
        {
        }
    }
}
