using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class EnemyVisuals : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private Enemy enemy;

        public void Init(Enemy enemy)
        {
            this.enemy = enemy;

            enemy.OnMove += AnimateMove;
        }

        private void OnDestroy()
        {
            enemy.OnMove -= AnimateMove;
        }

        private void AnimateMove(bool isMoving)
        {
            animator.SetBool("isMoving", isMoving);
        }
    }
}