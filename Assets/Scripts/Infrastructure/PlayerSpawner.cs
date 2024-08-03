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

        public void Init(Input input)
        {
            this.input = input;
        }

        public void Spawn()
        {
            Player player = Instantiate(prefab, transform.position, Quaternion.identity);
            player.Init(input);
            players.Add(player);
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