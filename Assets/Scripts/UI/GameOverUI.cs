using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] Canvas canvas;

        private SceneManager sceneManager;

        public void Init(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
        }

        public void Show() => canvas.enabled = true;
        public void Hide() => canvas.enabled = false;
        public void Restart() => sceneManager.LoadGameScene();
        public void Exit() => sceneManager.ExitGame();
    }
}