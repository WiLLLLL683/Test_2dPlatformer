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

        private StateMachine stateMachine = new();

        private void Awake()
        {
            stateMachine.AddState(new InitState(stateMachine));
            stateMachine.AddState(new GameplayState(playerSpawner, enemySpawners));
            stateMachine.AddState(new GameOverState());

            stateMachine.EnterState<InitState>();
        }
    }
}