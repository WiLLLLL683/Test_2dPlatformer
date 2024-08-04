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
        [SerializeField] private PlayerAudio playerAudio;

        public event Action<bool> OnMove;
        public event Action OnDeath;

        private const float AUDIO_DESTROY_DELAY = 5f;
        private Input input;
        private bool isEnabled;

        public void Init(Input input, BulletSpawner bulletSpawner)
        {
            this.input = input;
            inventory.Init();
            singleAttack.Init(inventory, bulletSpawner);
            burstAttack.Init(inventory, bulletSpawner);
            var attacks = new BulletAttackBase[2] { singleAttack, burstAttack };
            visuals.Init(this, attacks);
            playerAudio.Init(this, attacks);
            Enable();
        }

        private void OnDestroy()
        {
            Destroy(playerAudio, AUDIO_DESTROY_DELAY);
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
            health.OnDeath += Die;
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
            health.OnDeath -= Die;
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
        private void ShootSingle()
        {
            singleAttack.Attack(transform.right * transform.localScale.x);
        }
        private void ShootBurst()
        {
            burstAttack.Attack(transform.right * transform.localScale.x);
        }
        private void Die()
        {
            OnDeath?.Invoke();
            Disable();
        }
    }
}