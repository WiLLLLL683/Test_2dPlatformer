using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Platformer
{
    public class BulletSpawner
    {
        private ObjectPool<Bullet> pool;
        private Bullet prefab;
        private int damage;
        private Vector2 position;
        private Vector2 direction;

        public BulletSpawner()
        {
            pool = new(Create, Get, Release, Destroy, true, 10, 1000);
        }

        public Bullet Spawn(Bullet prefab, int damage, Vector2 position, Vector2 direction)
        {
            this.prefab = prefab;
            this.damage = damage;
            this.position = position;
            this.direction = direction;

            return pool.Get();
        }

        private Bullet Create()
        {
            return GameObject.Instantiate(prefab, position, Quaternion.identity);
        }

        private void Get(Bullet bullet)
        {
            bullet.transform.position = position;
            bullet.Init(direction, damage, pool);
            bullet.gameObject.SetActive(true);
        }

        private void Release(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void Destroy(Bullet bullet)
        {
            GameObject.Destroy(bullet.gameObject);
        }
    }
}