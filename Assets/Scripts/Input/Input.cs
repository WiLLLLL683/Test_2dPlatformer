using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer
{
    public class Input
    {
        public event Action OnShootInput;
        public event Action OnShootBurstInput;
        public event Action<Vector2> OnMoveInput;

        private readonly GameplayConfig config;
        private readonly GameControls controls;

        private float shootPressedTimer;

        public Input(GameplayConfig config)
        {
            this.config = config;
            controls = new();
        }

        public void Enable()
        {
            controls.Enable();
            controls.Gameplay.Shoot.started += ShootPressed;
            controls.Gameplay.Shoot.canceled += ShootUnPressed;
        }

        public void Disable()
        {
            controls.Disable();
            controls.Gameplay.Shoot.started -= ShootPressed;
            controls.Gameplay.Shoot.canceled -= ShootUnPressed;
        }

        public void Update()
        {
            if (controls.Gameplay.Movement.IsPressed())
            {
                MoveInput();
            }

            shootPressedTimer -= Time.deltaTime;

            if (controls.Gameplay.Shoot.IsInProgress() &&
                shootPressedTimer <= 0)
            {
                ShootBurstInput();
            }
        }

        private void ShootPressed(InputAction.CallbackContext obj) => shootPressedTimer = config.buttonHoldTime;
        private void ShootUnPressed(InputAction.CallbackContext obj)
        {
            if (shootPressedTimer > 0)
            {
                ShootInput();
            }
        }

        private void ShootInput() => OnShootInput?.Invoke();
        private void ShootBurstInput() => OnShootBurstInput?.Invoke();
        private void MoveInput()
        {
            Vector2 direction = controls.Gameplay.Movement.ReadValue<Vector2>();
            OnMoveInput?.Invoke(direction.normalized);
        }
    }
}