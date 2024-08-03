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

        public override void Init(InventoryBase inventory)
        {
            this.inventory = inventory;
        }

        public override void Attack(Vector2 direction)
        {
            if (inventory.TryGetItem("Bullet", out ItemData bulletItem) &&
                bulletItem.Amount > 0)
            {
                Bullet bullet = GameObject.Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
                bullet.Init(direction, damage);
                bulletItem.Amount--;
            }
        }
    }
}
