using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private MovementBase movement;
        [SerializeField] private HealthBase health;
        [SerializeField] private BulletAttackBase singleAttack;
        [SerializeField] private BulletAttackBase burstAttack;
        [SerializeField] private InventoryBase inventory;
        [SerializeField] private PlayerVisuals visuals;

        public event Action<bool> OnMove;

        private Input input;
        private bool isEnabled;

        public void Init(Input input, BulletSpawner bulletSpawner)
        {
            this.input = input;
            inventory.Init();
            singleAttack.Init(inventory, bulletSpawner);
            burstAttack.Init(inventory, bulletSpawner);
            visuals.Init(this);
            Enable();
        }

        private void OnDestroy()
        {
            Disable();
        }

        public void Enable()
        {
            if (isEnabled)
                return;

            isEnabled = true;
            input.OnMoveInput += Move;
            input.OnNoMoveInput += NoMove;
            input.OnShootInput += ShootSingle;
            input.OnShootBurstInput += ShootBurst;
            health.OnDeath += OnDeath;
        }

        public void Disable()
        {
            if (!isEnabled)
                return;

            isEnabled = false;
            input.OnMoveInput -= Move;
            input.OnNoMoveInput -= NoMove;
            input.OnShootInput -= ShootSingle;
            input.OnShootBurstInput -= ShootBurst;
            health.OnDeath -= OnDeath;
        }

        private void Move(Vector2 direction)
        {
            movement.Move(direction);
            OnMove?.Invoke(true);
        }
        private void NoMove()
        {
            OnMove?.Invoke(false);
        }
        private void ShootSingle() => singleAttack.Attack(transform.right * transform.localScale.x);
        private void ShootBurst() => burstAttack.Attack(transform.right * transform.localScale.x);
        private void OnDeath() => Disable();
    }
}