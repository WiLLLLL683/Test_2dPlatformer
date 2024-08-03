using System;
using UnityEngine;
using Utils;

namespace Platformer
{
    class GameplayState : IState
    {
        private readonly Input input;
        private readonly SceneManager sceneManager;
        private readonly PlayerSpawner playerSpawner;
        private readonly EnemySpawner[] enemySpawners;
        private readonly HudUI hudUI;
        private readonly GameOverUI gameOverUI;

        private const float ENEMY_SPAWN_DELAY = 10f;

        private float enemySpawnTimer;

        public GameplayState(Input input, SceneManager sceneManager, PlayerSpawner playerSpawner, EnemySpawner[] enemySpawners, HudUI hudUI, GameOverUI gameOverUI)
        {
            this.input = input;
            this.sceneManager = sceneManager;
            this.playerSpawner = playerSpawner;
            this.enemySpawners = enemySpawners;
            this.hudUI = hudUI;
            this.gameOverUI = gameOverUI;
        }

        public void OnEnter()
        {
            input.Enable();

            //spawn actors
            Player player = playerSpawner.Spawn();
            SpawnEnemy();

            //Init UI
            InventoryBase inventory = player.gameObject.GetComponent<InventoryBase>();
            inventory.TryGetItem("Bullet", out ItemData bulletItem);
            hudUI.Init(bulletItem);
            gameOverUI.Init(sceneManager);
        }

        private void SpawnEnemy()
        {
            int random = UnityEngine.Random.Range(0, enemySpawners.Length);
            enemySpawners[random].Spawn();
            enemySpawnTimer = ENEMY_SPAWN_DELAY;
        }

        public void OnExit()
        {

        }

        public void OnUpdate()
        {
            enemySpawnTimer -= Time.deltaTime;

            if (enemySpawnTimer <= 0)
            {
                SpawnEnemy();
            }
        }
    }
}
