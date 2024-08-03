using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy prefab;

        private List<Enemy> enemies = new();

        public void Spawn()
        {
            Enemy enemy = Instantiate(prefab, transform.position, Quaternion.identity);
            enemies.Add(enemy);
        }

        public void Clear()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Destroy(enemies[i].gameObject);
            }
        }
    }
}