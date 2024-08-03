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
        }
    }
}
