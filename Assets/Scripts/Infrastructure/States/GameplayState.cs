using System;
using Utils;

namespace Platformer
{
    class GameplayState : IState
    {
        private readonly PlayerSpawner playerSpawner;
        private readonly EnemySpawner[] enemySpawners;

        public GameplayState(PlayerSpawner playerSpawner, EnemySpawner[] enemySpawners)
        {
            this.playerSpawner = playerSpawner;
            this.enemySpawners = enemySpawners;
        }

        public void OnEnter()
        {
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
