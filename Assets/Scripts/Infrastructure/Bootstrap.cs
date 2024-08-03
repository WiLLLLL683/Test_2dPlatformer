using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Platformer
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner playerSpawner;
        [SerializeField] private EnemySpawner[] enemySpawners;
        [SerializeField] private HudUI hudUI;
        [SerializeField] private GameOverUI gameOverUI;
        [SerializeField] private ItemSetConfig allItemsConfig;

        private StateMachine stateMachine = new();
        private Input input;
        private ItemSpawner itemSpawner;
        private SceneManager sceneManager;

        private void Awake()
        {
            input = new();
            itemSpawner = new(allItemsConfig);
            sceneManager = new();

            stateMachine.AddState(new InitState(stateMachine, input, playerSpawner, enemySpawners, itemSpawner));
            stateMachine.AddState(new GameplayState(stateMachine, input, sceneManager, playerSpawner, enemySpawners, hudUI, gameOverUI));
            stateMachine.AddState(new GameOverState(input, gameOverUI));

            stateMachine.EnterState<InitState>();
        }

        private void Update()
        {
            input.Update();
            stateMachine.Update();
        }
    }
}