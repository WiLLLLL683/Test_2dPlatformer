using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Platformer
{
    public class Bullet : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private MovementBase movement;

        private Vector2 direction;
        private int damage;
        private ObjectPool<Bullet> pool;

        public void Init(Vector2 direction, int damage, ObjectPool<Bullet> pool)
        {
            this.direction = direction;
            this.damage = damage;
            this.pool = pool;
        }

        private void Update()
        {
            movement.Move(direction);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageble>(out IDamageble damageble))
            {
                damageble.TakeDamage(damage);
            }

            pool.Release(this);
        }
    }
}