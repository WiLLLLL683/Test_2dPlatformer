using System;
using UnityEngine;

namespace Platformer
{
    public abstract class HealthBase : MonoBehaviour
    {
        public abstract event Action OnDie;
        public abstract event Action<(int amount, int currentHealth, int maxHealth)> OnDamageTaken;

        public abstract void TakeDamage(int amount);
    }
}