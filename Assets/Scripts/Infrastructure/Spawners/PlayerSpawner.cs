using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Player prefab;

        private List<Player> players = new();
        private Input input;
        private BulletSpawner bulletSpawner;

        public void Init(Input input, BulletSpawner bulletSpawner)
        {
            this.input = input;
            this.bulletSpawner = bulletSpawner;
        }

        public Player Spawn()
        {
            Player player = Instantiate(prefab, transform.position, Quaternion.identity);
            player.Init(input, bulletSpawner);
            players.Add(player);
            return player;
        }

        public void Clear()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Destroy(players[i].gameObject);
            }
        }
    }
}