using UnityEngine;

namespace Platformer
{
    public abstract class AttackBase: MonoBehaviour
    {
        public abstract void Attack(Vector2 direction);
    }
}