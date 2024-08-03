using System;
using Utils;

namespace Platformer
{
    class GameplayState : IState
    {
        private readonly Input input;
        private readonly PlayerSpawner playerSpawner;
        private readonly EnemySpawner[] enemySpawners;
        private readonly HudUI hudUI;

        public GameplayState(Input input, PlayerSpawner playerSpawner, EnemySpawner[] enemySpawners, HudUI hudUI)
        {
            this.input = input;
            this.playerSpawner = playerSpawner;
            this.enemySpawners = enemySpawners;
            this.hudUI = hudUI;
        }

        public void OnEnter()
        {
            input.Enable();

            //spawn actors
            Player player = playerSpawner.Spawn();
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].Spawn();
            }

            //Init UI
            InventoryBase inventory = player.gameObject.GetComponent<InventoryBase>();
            inventory.TryGetItem("Bullet", out Item bulletItem);
            hudUI.Init(bulletItem);

        }

        public void OnExit()
        {
        }
    }
}
