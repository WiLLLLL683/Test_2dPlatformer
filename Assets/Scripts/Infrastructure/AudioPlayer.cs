using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource background;
        [SerializeField] private AudioSource playerSFX;
        [SerializeField] private AudioSource enemySFX;

        public void PlayBackground(AudioClip clip) => Play(clip, background);
        public void PlayEnemySFX(AudioClip clip) => Play(clip, enemySFX);
        public void PlayPlayerSFX(AudioClip clip) => Play(clip, playerSFX);

        private void Play(AudioClip clip, AudioSource source)
        {
            source.PlayOneShot(clip);
        }
    }
}