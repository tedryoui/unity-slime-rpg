using System.Collections.Generic;
using UnityEngine;

namespace SlimeRPG
{
    public class SlimeIdleState : State<Slime>
    {
        private float _attackDistance;

        private List<Enemy> GetAliveEnemies => Level.GetSpawner.enemies;
        
        public SlimeIdleState(Slime actor) : base(actor)
        {
            _attackDistance = actor.AttackDistanceStatParameter.Value;
        }

        public override void DoState()
        {
            var slimeX = _actor.transform.position.x;
            
            foreach (var enemy in GetAliveEnemies)
            {
                var enemyX = enemy.transform.position.x;
                                
                if (slimeX + _attackDistance >= enemyX)
                {
                    _actor.Target = enemy;
                    _actor.SetState(_actor.AttackState);
                }
            }
        }

    }
}