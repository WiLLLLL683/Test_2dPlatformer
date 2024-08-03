using System;
using UnityEngine;

namespace Platformer
{
    public class DelayShoot : BulletAttackBase
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform gunPoint;
        [SerializeField] private int damage;
        [SerializeField] private float delay;

        private InventoryBase inventory;
        private BulletSpawner bulletSpawner;
        private float shootTimer;

        public override void Init(InventoryBase inventory, BulletSpawner bulletSpawner)
        {
            this.inventory = inventory;
            this.bulletSpawner = bulletSpawner;
        }

        private void Update()
        {
            shootTimer -= Time.deltaTime;
        }

        public override void Attack(Vector2 direction)
        {
            if (shootTimer <= 0 &&
                inventory.TryGetItem("Bullet", out ItemData bulletItem) &&
                bulletItem.Amount > 0)
            {
                bulletSpawner.Spawn(bulletPrefab, damage, gunPoint.position, direction);
                bulletItem.Amount --;
                shootTimer = delay;
            }
        }
    }
}
