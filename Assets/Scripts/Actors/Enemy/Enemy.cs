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

        public event Action<bool> OnMove;

        private bool isEnabled;

        public void Init(float moveSpeed, ItemSpawner itemSpawner)
        {
            itemDrop.Init(itemSpawner);
            movement.Init(moveSpeed);
            visuals.Init(this);
            Enable();
        }

        private void OnDestroy()
        {
            Disable();
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
            health.OnDeath += OnDeath;
        }

        public void Disable()
        {
            if (!isEnabled)
                return;

            isEnabled = false;
            health.OnDeath -= OnDeath;
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

        private void OnDeath()
        {
            itemDrop.DropItem();
            Destroy(gameObject);
        }
    }
}