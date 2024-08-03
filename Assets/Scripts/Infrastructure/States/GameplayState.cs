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
        private readonly EnemySpawner[] enemySpawners;
        private readonly HudUI hudUI;
        private readonly GameOverUI gameOverUI;
        private readonly GameplayConfig gameplayConfig;

        private float enemySpawnTimer;
        private Health playerHealth;
        private ItemData criticalItem;

        public GameplayState(StateMachine stateMachine, Input input, SceneManager sceneManager, PlayerSpawner playerSpawner, EnemySpawner[] enemySpawners, HudUI hudUI, GameOverUI gameOverUI, GameplayConfig gameplayConfig)
        {
            this.stateMachine = stateMachine;
            this.input = input;
            this.sceneManager = sceneManager;
            this.playerSpawner = playerSpawner;
            this.enemySpawners = enemySpawners;
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

            //gameover on criticalItem empty
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
            for (int i = 0; i < gameplayConfig.enemySpawnCount; i++)
            {
                int random = UnityEngine.Random.Range(0, enemySpawners.Length);
                enemySpawners[random].Spawn();
            }

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
