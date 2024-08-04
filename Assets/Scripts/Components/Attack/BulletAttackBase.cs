using System;
using UnityEngine;

namespace Platformer
{
    public abstract class BulletAttackBase : AttackBase
    {
        [SerializeField] protected string consumeItemId;

        public abstract event Action OnShoot;
        public abstract void Init(InventoryBase inventory, BulletSpawner bulletSpawner);
    }
}