using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MovementBase movement;
        [SerializeField] private HealthBase health;
        [SerializeField] private AttackBase singleAttack;
        [SerializeField] private AttackBase burstAttack;

        private Input input;

        public void Init(Input input)
        {
            this.input = input;

            input.OnMoveInput += movement.Move;
            input.OnShootInput += ShootSingle;
            input.OnShootBurstInput += ShootBurst;
        }

        private void OnDestroy()
        {
            input.OnMoveInput -= movement.Move;
            input.OnShootInput -= ShootSingle;
            input.OnShootBurstInput -= ShootBurst;
        }

        private void ShootSingle()
        {
            singleAttack.Attack(transform.right);
        }

        private void ShootBurst()
        {
            burstAttack.Attack(transform.right);
        }
    }
}