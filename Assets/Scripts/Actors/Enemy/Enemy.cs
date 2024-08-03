using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Platformer
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private MovementBase movement;
        [SerializeField] private AttackBase attack;
        [SerializeField] private HealthBase health;
        [SerializeField] private Rigidbody2D rigidbody2d;
        [SerializeField] private float targetDetectionRadius;
        [SerializeField] private LayerMask targetLayer;

        private Transform target;

        public void Init()
        {
            health.OnDie += OnDeath;
        }

        private void OnDestroy()
        {
            health.OnDie -= OnDeath;
        }

        private void Update()
        {
            if (health.IsDead)
            {
                return;
            }

            FindTarget();
            MoveToTarget();
        }

        private void FindTarget()
        {
            Collider2D collision = Physics2D.OverlapCircle(transform.position, targetDetectionRadius, targetLayer);

            if (collision != null &&
                collision.TryGetComponent<Player>(out Player player))
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
            rigidbody2d.freezeRotation = false;
            //TODO drop item
        }
    }
}