using UnityEngine;

namespace Platformer
{
    public abstract class TargetDetectionBase: MonoBehaviour
    {
        public abstract Transform Target { get; }

        public abstract void FindTarget();
    }
}