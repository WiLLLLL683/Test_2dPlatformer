namespace Platformer
{
    public abstract class BulletAttackBase : AttackBase
    {
        public abstract void Init(InventoryBase inventory, BulletSpawner bulletSpawner);
    }
}