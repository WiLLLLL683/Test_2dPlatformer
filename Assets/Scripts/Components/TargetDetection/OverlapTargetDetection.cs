using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class OverlapTargetDetection : TargetDetectionBase
    {
        [SerializeField] private float targetDetectionRadius;
        [SerializeField] private LayerMask targetLayer;

        public override Transform Target => target;

        private Transform target;

        public override void FindTarget()
        {
            Collider2D collision = Physics2D.OverlapCircle(transform.position, targetDetectionRadius, targetLayer);

            if (collision != null &&
                collision.TryGetComponent<Player>(out Player player) &&
                !collision.GetComponent<Health>().IsDead)
            {
                target = player.transform;
            }
            else
            {
                target = null;
            }
        }
    }
}