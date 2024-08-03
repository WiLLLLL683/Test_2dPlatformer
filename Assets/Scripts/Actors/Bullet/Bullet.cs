using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class Bullet : MonoBehaviour
    {
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

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent<IDamageble>(out IDamageble damageble))
            {
                damageble.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}