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

        private StateMachine stateMachine = new();
        private Input input;

        private void Awake()
        {
            input = new Input();

            stateMachine.AddState(new InitState(stateMachine, input, playerSpawner, enemySpawners));
            stateMachine.AddState(new GameplayState(input, playerSpawner, enemySpawners, hudUI));
            stateMachine.AddState(new GameOverState());

            stateMachine.EnterState<InitState>();
        }

        private void Update()
        {
            input.Update();
        }
    }
}