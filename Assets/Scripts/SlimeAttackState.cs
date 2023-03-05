using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeRPG
{
    public class SlimeAttackState : State<Slime>
    {
        private float _timePast;
        
        private static readonly int AttackAnimatorTrigger = Animator.StringToHash("Attack");

        public SlimeAttackState(Slime actor) : base(actor)
        {
            _timePast = _actor.AttackDelayStatParameter.Value;
        }

        public override void DoState()
        {
            if (_actor.Target.Equals(null))
            {
                _actor.SetState(_actor.IdleState);
                return;
            }

            _timePast += Time.deltaTime;
            if (_timePast >= _actor.AttackDelayStatParameter.Value)
            {
                _timePast = 0.0f;
                Level.GetPlayer.StartCoroutine(ShootProjectile());
            }
        }

        private IEnumerator ShootProjectile()
        {
            if (_actor.Target.Equals(null)) yield break;
            
            var projectile =
                Object.Instantiate(_actor.Projectile.prefab, _actor.transform.position, Quaternion.identity);
            _actor.GetAnimator.SetTrigger(AttackAnimatorTrigger);
            
            var dst = Vector3.Distance(projectile.transform.position, _actor.Target.transform.position);
            var timePast = 0.0f;
            var from = projectile.transform.position;

            while (true)
            {
                if (_actor.Target.Equals(null))
                {
                    Object.Destroy(projectile);
                    break;
                }

                var to = _actor.Target.transform.position;

                var linear = Vector3.Lerp(from, to, timePast);
                var heightTime = Mathf.Lerp(0.0f, 2.0f, timePast);
                var height = _actor.Projectile.flyCurve.Evaluate(heightTime);

                projectile.transform.position = new Vector3()
                {
                    x = linear.x,
                    y = height * 5.0f,
                    z = linear.z
                };

                if (Vector3.Distance(projectile.transform.position, _actor.Target.transform.position) <= 1.0f)
                {
                    _actor.Target.ApplyDamage(_actor.attackDamage.Value * -1);
                    Object.Destroy(projectile);
                    break;
                }

                timePast += Time.deltaTime * _actor.ProjectileSpeedStatParameter.Value;
                yield return null;
            }
        }
    }
}