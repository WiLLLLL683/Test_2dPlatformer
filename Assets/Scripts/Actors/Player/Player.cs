using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MovementBase movement;
        [SerializeField] private HealthBase health;
        [SerializeField] private BulletAttackBase singleAttack;
        [SerializeField] private BulletAttackBase burstAttack;
        [SerializeField] private InventoryBase inventory;

        private Input input;

        public void Init(Input input)
        {
            this.input = input;
            inventory.Init();
            singleAttack.Init(inventory);
            burstAttack.Init(inventory);
            Enable();
        }

        private void OnDestroy()
        {
            Disable();
        }

        public void Enable()
        {
            input.OnMoveInput += movement.Move;
            input.OnShootInput += ShootSingle;
            input.OnShootBurstInput += ShootBurst;
            health.OnDeath += OnDeath;
        }

        public void Disable()
        {
            input.OnMoveInput -= movement.Move;
            input.OnShootInput -= ShootSingle;
            input.OnShootBurstInput -= ShootBurst;
            health.OnDeath -= OnDeath;
        }

        private void ShootSingle() => singleAttack.Attack(transform.right);
        private void ShootBurst() => burstAttack.Attack(transform.right);
        private void OnDeath()
        {
            Disable();
        }
    }
}