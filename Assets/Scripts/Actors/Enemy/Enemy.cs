using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Platformer
{
    public class Enemy : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private MovementBase movement;
        [SerializeField] private AttackBase attack;
        [SerializeField] private HealthBase health;
        [SerializeField] private ItemDropBase itemDrop;
        [SerializeField] private TargetDetectionBase targetDetection;
        [SerializeField] private EnemyVisuals visuals;
        [SerializeField] private EnemyAudio enemyAudio;

        public event Action<bool> OnMove;
        public event Action OnDeath;

        private const float AUDIO_DESTROY_DELAY = 5f;
        private bool isEnabled;

        public void Init(float moveSpeed, ItemSpawner itemSpawner, AudioPlayer audioPlayer)
        {
            itemDrop.Init(itemSpawner);
            movement.Init(moveSpeed);
            visuals.Init(this);
            enemyAudio.Init(this, audioPlayer);
            Enable();
        }

        private void OnDestroy()
        {
            Disable();
            enemyAudio.Disable();
            Destroy(enemyAudio.gameObject, AUDIO_DESTROY_DELAY);
        }

        private void Update()
        {
            if (!isEnabled)
                return;

            targetDetection.FindTarget();

            if (targetDetection.Target != null)
            {
                MoveToTarget();
            }
            else
            {
                NoMove();
            }
        }

        public void Enable()
        {
            if (isEnabled)
                return;

            isEnabled = true;
            health.OnDeath += Die;
        }

        public void Disable()
        {
            if (!isEnabled)
                return;

            isEnabled = false;
            health.OnDeath -= Die;
        }

        private void MoveToTarget()
        {
            Vector2 direction = targetDetection.Target.position - transform.position;
            direction = direction.normalized;
            movement.Move(direction);
            OnMove?.Invoke(true);
        }

        private void NoMove()
        {
            OnMove?.Invoke(false);
        }

        private void Die()
        {
            itemDrop.DropItem();
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}