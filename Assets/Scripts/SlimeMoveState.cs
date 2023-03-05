using UnityEngine;

namespace SlimeRPG
{
    public class SlimeMoveState : State<Slime>
    {
        private float _timePast;
        private float _timeDuration;
        private static readonly int IsMovingAnimationBoolean = Animator.StringToHash("isMoving");

        public SlimeMoveState(Slime actor) : base(actor)
        {
            _timePast = 0;
            _timeDuration = 3.0f;
        }

        public override void DoState()
        {
            _actor.GetAnimator.SetBool(IsMovingAnimationBoolean, true);
            _timePast += Time.deltaTime;

            if (_timePast >= _timeDuration)
            {
                _timePast = 0;
                _actor.SetState(_actor.IdleState);
                _actor.GetAnimator.SetBool(IsMovingAnimationBoolean, false);
                return;
            }
            
            _actor.transform.position += Vector3.right * (_actor.SpeedStatParameter.Value * Time.deltaTime);
        }
    }
}