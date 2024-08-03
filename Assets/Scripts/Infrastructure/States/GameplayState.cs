using System;
using UnityEngine;
using Utils;

namespace Platformer
{
    class GameplayState : IState
    {
        private readonly StateMachine stateMachine;
        private readonly Input input;
        private readonly SceneManager sceneManager;
        private readonly PlayerSpawner playerSpawner;
        private readonly EnemySpawner enemySpawner;
        private readonly HudUI hudUI;
        private readonly GameOverUI gameOverUI;
        private readonly GameplayConfig gameplayConfig;

        private float enemySpawnTimer;
        private Health playerHealth;
        private ItemData criticalItem;

        public GameplayState(StateMachine stateMachine, Input input, SceneManager sceneManager, PlayerSpawner playerSpawner, EnemySpawner enemySpawner, HudUI hudUI, GameOverUI gameOverUI, GameplayConfig gameplayConfig)
        {
            this.stateMachine = stateMachine;
            this.input = input;
            this.sceneManager = sceneManager;
            this.playerSpawner = playerSpawner;
            this.enemySpawner = enemySpawner;
            this.hudUI = hudUI;
            this.gameOverUI = gameOverUI;
            this.gameplayConfig = gameplayConfig;
        }

        public void OnEnter()
        {
            input.Enable();

            //spawn actors
            Player player = playerSpawner.Spawn();
            SpawnEnemies();

            //Init UI
            InventoryBase playerInventory = player.gameObject.GetComponent<InventoryBase>();
            hudUI.Init(playerInventory);
            gameOverUI.Init(sceneManager);

            //gameover on player die
            playerHealth = player.gameObject.GetComponent<Health>();
            playerHealth.OnDeath += GameOver;

            //gameover on critical item is empty
            if (playerInventory.TryGetItem(gameplayConfig.criticalItem, out ItemData criticalItem))
            {
                this.criticalItem = criticalItem;
                criticalItem.OnAmountChange += CheckCriticalItemAmount;
            }
            else
            {
                GameOver();
            }
        }

        public void OnExit()
        {
            playerHealth.OnDeath -= GameOver;
            if (criticalItem != null)
            {
                criticalItem.OnAmountChange -= CheckCriticalItemAmount;
            }
        }

        public void OnUpdate()
        {
            enemySpawnTimer -= Time.deltaTime;

            if (enemySpawnTimer <= 0)
            {
                SpawnEnemies();
            }
        }

        private void SpawnEnemies()
        {
            enemySpawner.SpawnMultiple(gameplayConfig.enemySpawnCount);
            enemySpawnTimer = gameplayConfig.enemySpawnDelay;
        }

        private void CheckCriticalItemAmount(int amount)
        {
            if (amount <= 0)
            {
                GameOver();
            }
        }

        private void GameOver() => stateMachine.EnterState<GameOverState>();
    }
}
