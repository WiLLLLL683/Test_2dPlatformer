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

        private Player player;
        private BulletAttackBase[] attacks;

        public void Init(Player player, BulletAttackBase[] attacks)
        {
            this.player = player;
            this.attacks = attacks;

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
        }

        public void Disable()
        {
            idleSourse.Stop();
            moveSourse.Stop();

            player.OnMove -= PlayMoveSound;
            player.OnDeath -= PlayDeathSound;
            for (int i = 0; i < attacks.Length; i++)
            {
                attacks[i].OnShoot -= PlayShootSound;
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

        private void PlayDeathSound()
        {
            dieSourse.PlayOneShot(dieSourse.clip);
        }

        private void PlayShootSound()
        {
            shootSourse.PlayOneShot(shootSourse.clip);
        }
    }
}