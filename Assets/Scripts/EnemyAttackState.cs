using UnityEngine;

namespace SlimeRPG
{
    public class EnemyAttackState : State<Enemy>
    {
        private float _timePast;
        private float _delay;
        private static readonly int VictoryAnimationTrigger = Animator.StringToHash("Victory");
        private static readonly int AttackAnimationTrigger = Animator.StringToHash("Attack");

        public EnemyAttackState(Enemy actor) : base(actor)
        {
            _delay = actor.AttackDelayStatParameter.Value;
        }

        public override void DoState()
        {
            if(_actor.Target.Equals(null))
            {
                _actor.GetAnimator.SetTrigger(VictoryAnimationTrigger);
                return;
            }

            _timePast += Time.deltaTime;

            if (_timePast >= _delay)
            {
                _timePast = 0;
                _actor.GetAnimator.SetTrigger(AttackAnimationTrigger);
                
                (_actor.Target as Slime)?.ApplyDamage(_actor.attackDamage.Value * -1);
            }
        }
    }
}