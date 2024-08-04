using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class PlayerVisuals : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private Player player;
        private BulletAttackBase[] attacks;

        public void Init(Player player, BulletAttackBase[] attacks)
        {
            this.player = player;
            this.attacks = attacks;

            player.OnMove += AnimateMove;
            for (int i = 0; i < attacks.Length; i++)
            {
                attacks[i].OnShoot += AnimateShoot;
            }
        }

        private void OnDestroy()
        {
            player.OnMove -= AnimateMove;
            for (int i = 0; i < attacks.Length; i++)
            {
                attacks[i].OnShoot -= AnimateShoot;
            }
        }

        private void AnimateMove(bool isMoving)
        {
            animator.SetBool("isMoving", isMoving);
        }

        private void AnimateShoot()
        {
            animator.SetTrigger("isShooting");
        }
    }
}