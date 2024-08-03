using System;
using Utils;

namespace Platformer
{
    class GameOverState : IState
    {
        private readonly Input input;
        private readonly GameOverUI gameOverUI;

        public GameOverState(Input input, GameOverUI gameOverUI)
        {
            this.input = input;
            this.gameOverUI = gameOverUI;
        }

        public void OnEnter()
        {
            input.Disable();
            gameOverUI.Show();
        }

        public void OnExit()
        {

        }

        public void OnUpdate()
        {

        }
    }
}
