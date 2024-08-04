using System;
using UnityEngine;

namespace Platformer
{
    public class SingleShoot : BulletAttackBase
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform gunPoint;
        [SerializeField] private int damage;

        private InventoryBase inventory;
        private BulletSpawner bulletSpawner;

        public override event Action OnShoot;

        public override void Init(InventoryBase inventory, BulletSpawner bulletSpawner)
        {
            this.inventory = inventory;
            this.bulletSpawner = bulletSpawner;
        }

        public override void Attack(Vector2 direction)
        {
            if (inventory.TryGetItem(consumeItemId, out ItemData bulletItem) &&
                bulletItem.Amount > 0)
            {
                bulletSpawner.Spawn(bulletPrefab, damage, gunPoint.position, direction);
                bulletItem.Amount--;
                OnShoot?.Invoke();
            }
        }
    }
}
