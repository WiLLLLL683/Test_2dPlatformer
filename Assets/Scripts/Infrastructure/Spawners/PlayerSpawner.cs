using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerSpawner
    {
        private readonly Player prefab;
        private readonly Transform spawnPoint;
        private readonly Input input;
        private readonly BulletSpawner bulletSpawner;

        private List<Player> players = new();

        public PlayerSpawner(Player prefab, Transform spawnPoint, Input input, BulletSpawner bulletSpawner)
        {
            this.prefab = prefab;
            this.spawnPoint = spawnPoint;
            this.input = input;
            this.bulletSpawner = bulletSpawner;
        }

        public Player Spawn()
        {
            Player player = GameObject.Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            player.Init(input, bulletSpawner);
            players.Add(player);
            return player;
        }

        public void Clear()
        {
            for (int i = 0; i < players.Count; i++)
            {
                GameObject.Destroy(players[i].gameObject);
            }
        }
    }
}