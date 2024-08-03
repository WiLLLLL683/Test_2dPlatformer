using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Platformer
{
    class LinearMovement : MovementBase
    {
        [SerializeField] private float speed;

        public override void Move(Vector2 inputDirection)
        {
            Vector3 direction = new(inputDirection.x, 0, 0);
            transform.position += Time.deltaTime * speed * direction;
            FlipDirection(inputDirection);
        }

        public override void SetSpeed(float speed) => this.speed = speed;

        private void FlipDirection(Vector2 inputDirection)
        {
            inputDirection = inputDirection.normalized;
            int horizontalDirection = Mathf.CeilToInt(inputDirection.x);

            if (horizontalDirection == 0)
                return;

            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * horizontalDirection;
            transform.localScale = scale;
        }
    }
}
