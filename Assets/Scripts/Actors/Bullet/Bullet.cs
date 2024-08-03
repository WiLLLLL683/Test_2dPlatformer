using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class Bullet : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private MovementBase movement;

        private Vector2 direction;
        private int damage;

        public void Init(Vector2 direction, int damage)
        {
            this.direction = direction;
            this.damage = damage;
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

            Destroy(gameObject);
        }
    }
}