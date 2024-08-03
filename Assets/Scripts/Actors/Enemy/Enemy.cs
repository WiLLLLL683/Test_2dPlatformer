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
        [Header("TargetDetection")]
        [SerializeField] private float targetDetectionRadius;
        [SerializeField] private LayerMask targetLayer;

        private Transform target;
        private bool isEnabled;

        public void Init(float moveSpeed, ItemSpawner itemSpawner)
        {
            itemDrop.Init(itemSpawner);
            movement.Init(moveSpeed);
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

            FindTarget();

            if (target != null)
            {
                MoveToTarget();
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

        private void FindTarget()
        {
            Collider2D collision = Physics2D.OverlapCircle(transform.position, targetDetectionRadius, targetLayer);

            if (collision != null &&
                collision.TryGetComponent<Player>(out Player player) &&
                !collision.GetComponent<Health>().IsDead)
            {
                target = player.transform;
            }
            else
            {
                target = null;
            }
        }

        private void MoveToTarget()
        {
            if (target == null)
                return;

            Vector2 direction = target.position - transform.position;
            direction = direction.normalized;
            movement.Move(direction);
        }

        private void OnDeath()
        {
            itemDrop.DropItem();
            Destroy(gameObject);
        }
    }
}