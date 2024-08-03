using System;
using UnityEngine;

namespace Platformer
{
    public abstract class HealthBase : MonoBehaviour
    {
        public abstract bool IsDead { get; protected set; }

        public abstract event Action OnDeath;
        public abstract event Action<(int amount, int currentHealth, int maxHealth)> OnDamageTaken;

        public abstract void TakeDamage(int amount);
    }
}