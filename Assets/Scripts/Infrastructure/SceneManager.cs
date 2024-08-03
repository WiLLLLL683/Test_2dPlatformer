using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class SceneManager
    {
        private const string GAMEPLAY_SCENE_NAME = "Gameplay";

        public void LoadGameScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(GAMEPLAY_SCENE_NAME);
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}