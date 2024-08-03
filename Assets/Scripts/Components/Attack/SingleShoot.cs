using System;
using UnityEngine;

namespace Platformer
{
    public class SingleShoot : AttackBase
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform gunPoint;
        [SerializeField] private int damage;

        public override void Attack(Vector2 direction)
        {
            Bullet bullet = GameObject.Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
            bullet.Init(direction, damage);
        }
    }
}
