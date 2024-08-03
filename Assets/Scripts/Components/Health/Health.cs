using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Health : HealthBase, IDamageble
    {
        public override event Action OnDie;
        public override event Action<(int amount, int currentHealth, int maxHealth)> OnDamageTaken;

        private int currentHealth;
        private int maxHealth;

        public override void TakeDamage(int amount)
        {
            if (amount <= 0)
                return;

            currentHealth -= amount;
            OnDamageTaken?.Invoke((amount, currentHealth, maxHealth));

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            OnDie?.Invoke();
        }
    }
}