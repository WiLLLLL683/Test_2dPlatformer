﻿using UnityEngine;

namespace Platformer
{
    public abstract class MovementBase: MonoBehaviour
    {
        public abstract void Move(Vector2 inputDirection);
        public abstract void Init(float speed);
    }
}