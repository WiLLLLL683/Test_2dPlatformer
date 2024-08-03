using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class BulletSpawner
    {
        public Bullet Spawn(Bullet prefab, int damage, Vector2 position, Vector2 direction)
        {
            Bullet bullet = GameObject.Instantiate(prefab, position, Quaternion.identity);
            bullet.Init(direction, damage);
            return bullet;
        }
    }
}