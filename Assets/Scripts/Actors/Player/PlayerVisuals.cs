using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class PlayerVisuals : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private Player player;

        public void Init(Player player)
        {
            this.player = player;

            player.OnMove += AnimateMove;
            player.OnShoot += AnimateShoot;
        }

        private void OnDestroy()
        {
            player.OnMove -= AnimateMove;
            player.OnShoot -= AnimateShoot;
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