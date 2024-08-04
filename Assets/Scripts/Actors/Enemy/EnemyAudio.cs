﻿using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class EnemyAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource idleSourse;
        [SerializeField] private AudioSource moveSourse;
        [SerializeField] private AudioSource dieSourse;

        private Enemy enemy;

        public void Init(Enemy enemy)
        {
            this.enemy = enemy;

            transform.position = Camera.main.transform.position;
            transform.parent = Camera.main.transform;

            idleSourse.Play();
            moveSourse.Play();

            enemy.OnMove += PlayMoveSound;
            enemy.OnDeath += PlayDeathSound;
        }

        public void Disable()
        {
            if (idleSourse != null)
            {
                idleSourse.Stop();
            }
            if (moveSourse != null)
            {
                moveSourse.Stop();
            }

            if (enemy != null)
            {
                enemy.OnMove -= PlayMoveSound;
                enemy.OnDeath -= PlayDeathSound;
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
    }
}