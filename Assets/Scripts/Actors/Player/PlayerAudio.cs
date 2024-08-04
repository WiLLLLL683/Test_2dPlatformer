using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class PlayerAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource idleSourse;
        [SerializeField] private AudioSource moveSourse;
        [SerializeField] private AudioSource shootSourse;
        [SerializeField] private AudioSource dieSourse;
        [SerializeField] private AudioSource pickUpSourse;

        private Player player;
        private BulletAttackBase[] attacks;
        private InventoryBase inventory;

        public void Init(Player player, BulletAttackBase[] attacks, InventoryBase inventory)
        {
            this.player = player;
            this.attacks = attacks;
            this.inventory = inventory;

            transform.position = Camera.main.transform.position;
            transform.parent = Camera.main.transform;

            idleSourse.Play();
            moveSourse.Play();

            player.OnMove += PlayMoveSound;
            player.OnDeath += PlayDeathSound;
            for (int i = 0; i < attacks.Length; i++)
            {
                attacks[i].OnShoot += PlayShootSound;
            }
            inventory.OnItemPickUp += PlayPickUpSound;
        }

        public void Disable()
        {
            if (idleSourse != null)
            {
                idleSourse?.Stop();
            }
            if (moveSourse != null)
            {
                moveSourse?.Stop();
            }

            if (player != null)
            {
                player.OnMove -= PlayMoveSound;
                player.OnDeath -= PlayDeathSound;
                for (int i = 0; i < attacks.Length; i++)
                {
                    attacks[i].OnShoot -= PlayShootSound;
                }
                inventory.OnItemPickUp -= PlayPickUpSound;
            }
        }

        private void PlayMoveSound(bool isMoving)
        {
            if (isMoving)
            {
                moveSourse.mute = false;
            }
            else
            {
                moveSourse.mute = true;
            }
        }

        private void PlayDeathSound() => dieSourse.PlayOneShot(dieSourse.clip);
        private void PlayShootSound() => shootSourse.PlayOneShot(shootSourse.clip);
        private void PlayPickUpSound() => pickUpSourse.PlayOneShot(pickUpSourse.clip);
    }
}