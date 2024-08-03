using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class TouchAttack : AttackBase
    {
        [SerializeField] private int damage;
        [SerializeField] private LayerMask targetLayer;

        public override void Attack(Vector2 direction)
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!((targetLayer & (1 << collision.gameObject.layer)) != 0))
                return;

            if (collision.gameObject.TryGetComponent<IDamageble>(out IDamageble damageble))
            {
                damageble.TakeDamage(damage);
            }
        }
    }
}