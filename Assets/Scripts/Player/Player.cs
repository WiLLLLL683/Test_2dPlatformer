using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Input input;

        public void Init(Input input)
        {
            this.input = input;
            input.OnMoveInput += Move;
            input.OnShootInput += ShootSingle;
            input.OnShootBurstInput += ShootBurst;
        }
        private void OnDestroy()
        {
            input.OnMoveInput -= Move;
            input.OnShootInput -= ShootSingle;
            input.OnShootBurstInput -= ShootBurst;
        }

        private void Move(Vector2 inputDirection)
        {
            Vector3 direction = new(inputDirection.x, 0, 0);
            transform.position += Time.deltaTime * speed * direction;
        }
        private void ShootSingle()
        {
            Debug.Log("Single Shoot");
        }
        private void ShootBurst()
        {
            Debug.Log("Burst Shoot");
        }
    }
}