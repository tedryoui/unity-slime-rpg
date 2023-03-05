using System;
using UnityEngine;

namespace SlimeRPG
{
    public class EnemyMoveState : State<Enemy>
    {
        private float _speed;
        private static readonly int VictoryAnimationTrigger = Animator.StringToHash("Victory");
        private static readonly int IsMovingAnimationBoolean = Animator.StringToHash("isMoving");

        private const float Offset = 2.0f;

        public EnemyMoveState(Enemy actor) : base(actor)
        {
            _speed = actor.SpeedStatParameter.Value;
        }

        public override void DoState()
        {
            if (_actor.Target == null)
            {
                _actor.GetAnimator.SetTrigger(VictoryAnimationTrigger);
                _actor.GetAnimator.SetBool(IsMovingAnimationBoolean, false);
                return;
            }

            var target = _actor.transform.position;
            target.x = _actor.Target.transform.position.x + Offset;

            var move = Vector3.MoveTowards(_actor.transform.position, target, _speed * Time.deltaTime);
            _actor.transform.position = move;
            _actor.GetAnimator.SetBool(IsMovingAnimationBoolean, true);

            if (_actor.transform.position.x <= _actor.Target.transform.position.x + Offset)
            {
                _actor.SetState(_actor.AttackState);
            }
        }
    }
}