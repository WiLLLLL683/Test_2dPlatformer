using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Platformer
{
    public class Bootstrap : MonoBehaviour
    {
        private StateMachine stateMachine = new();

        private void Awake()
        {
            stateMachine.AddState(new InitState());
            stateMachine.AddState(new GameplayState());
            stateMachine.AddState(new GameOverState());

            stateMachine.EnterState<InitState>();
        }
    }
}