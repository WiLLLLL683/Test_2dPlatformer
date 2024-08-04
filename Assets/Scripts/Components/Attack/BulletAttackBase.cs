using System;

namespace Platformer
{
    public abstract class BulletAttackBase : AttackBase
    {
        public abstract event Action OnShoot;
        public abstract void Init(InventoryBase inventory, BulletSpawner bulletSpawner);
    }
}