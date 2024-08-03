using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Platformer
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("Spawners")]
        [SerializeField] private PlayerSpawner playerSpawner;
        [SerializeField] private EnemySpawner[] enemySpawners;
        [Header("UI")]
        [SerializeField] private HudUI hudUI;
        [SerializeField] private GameOverUI gameOverUI;
        [Header("Config")]
        [SerializeField] private ItemSetConfig allItemsConfig;
        [SerializeField] private GameplayConfig gameplayConfig;

        private StateMachine stateMachine = new();
        private Input input;
        private ItemSpawner itemSpawner;
        private BulletSpawner bulletSpawner;
        private SceneManager sceneManager;

        private void Awake()
        {
            //Initialization
            input = new();
            itemSpawner = new(allItemsConfig);
            bulletSpawner = new();
            sceneManager = new();
            playerSpawner.Init(input, bulletSpawner);
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].Init(itemSpawner);
            }

            stateMachine.AddState(new GameplayState(stateMachine, input, sceneManager, playerSpawner, enemySpawners, hudUI, gameOverUI, gameplayConfig));
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