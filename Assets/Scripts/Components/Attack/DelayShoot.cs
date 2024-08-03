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
        private float shootDelay;

        private void Update()
        {
            shootDelay -= Time.deltaTime;
        }

        public override void Init(InventoryBase inventory)
        {
            this.inventory = inventory;
        }

        public override void Attack(Vector2 direction)
        {
            if (shootDelay <= 0 &&
                inventory.TryGetItem("Bullet", out ItemData bulletItem) &&
                bulletItem.Amount > 0)
            {
                Bullet bullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
                bullet.Init(direction, damage);
                bulletItem.Amount --;
                shootDelay = delay;
            }
        }
    }
}
