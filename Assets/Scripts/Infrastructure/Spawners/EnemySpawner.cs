using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemySpawner
    {
        private SpawnConfig config;
        private List<Transform> spawnPoints;
        private List<Enemy> enemies = new();
        private ItemSpawner itemSpawner;
        private readonly AudioPlayer audioPlayer;

        public EnemySpawner(SpawnConfig config, List<Transform> spawnPoints, ItemSpawner itemSpawner, AudioPlayer audioPlayer)
        {
            this.config = config;
            this.spawnPoints = spawnPoints;
            this.itemSpawner = itemSpawner;
            this.audioPlayer = audioPlayer;
        }

        public void SpawnMultiple(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Spawn();
            }
        }

        public Enemy Spawn()
        {
            //random spawn point
            int random = UnityEngine.Random.Range(0, spawnPoints.Count);
            Vector2 position = spawnPoints[random].position;

            //random prefab
            int randomPrefabIndex = UnityEngine.Random.Range(0, config.enemyPrefabs.Length);
            Enemy randomPrefab = config.enemyPrefabs[randomPrefabIndex];

            //spawn
            Enemy enemy = GameObject.Instantiate(randomPrefab, position, Quaternion.identity);
            float moveSpeed = UnityEngine.Random.Range(config.minMoveSpeed, config.maxMoveSpeed);
            enemy.Init(moveSpeed, itemSpawner, audioPlayer);
            enemies.Add(enemy);
            return enemy;
        }

        public void Clear()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                GameObject.Destroy(enemies[i].gameObject);
            }
        }
    }
}