using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Platformer
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("Spawners")]
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private List<Transform> enemySpawnPoints;
        [Header("UI")]
        [SerializeField] private HudUI hudUI;
        [SerializeField] private GameOverUI gameOverUI;
        [Header("Config")]
        [SerializeField] private ItemSetConfig allItemsConfig;
        [SerializeField] private GameplayConfig gameplayConfig;
        [SerializeField] private SpawnConfig spawnConfig;

        private StateMachine stateMachine = new();
        private Input input;
        private PlayerSpawner playerSpawner;
        private EnemySpawner enemySpawner;
        private ItemSpawner itemSpawner;
        private BulletSpawner bulletSpawner;
        private SceneManager sceneManager;

        private void Awake()
        {
            //Initialization
            input = new(gameplayConfig);
            itemSpawner = new(allItemsConfig);
            bulletSpawner = new();
            playerSpawner = new(spawnConfig.playerPrefab, playerSpawnPoint, input, bulletSpawner);
            enemySpawner = new(spawnConfig, enemySpawnPoints, itemSpawner);
            sceneManager = new();

            stateMachine.AddState(new GameplayState(stateMachine, input, sceneManager, playerSpawner, enemySpawner, hudUI, gameOverUI, gameplayConfig));
            stateMachine.AddState(new GameOverState(input, gameOverUI));

            stateMachine.EnterState<GameplayState>();
        }

        private void Update()
        {
            input.Update();
            stateMachine.Update();
        }
    }
}