using System;
using System.Collections;
using UnityEngine;

namespace SlimeRPG
{
    public class Enemy : Entity
    {
        public StatParameter SpeedStatParameter;
        public StatParameter AttackDelayStatParameter;
        public StatParameter CoinsRewardStatParameter;

        [SerializeField] private Animator _animator;
        private static readonly int DieAnimationTrigger = Animator.StringToHash("Die");

        public State<Enemy> MoveState { get; private set; }
        public State<Enemy> AttackState { get; private set; }
        public Animator GetAnimator => _animator;
        
        protected override void Start()
        {
            Despawn += OnDespawn;
            
            MoveState = new EnemyMoveState(this);
            AttackState = new EnemyAttackState(this);

            CrrState = MoveState;
            base.Start();
        }

        private void OnDespawn(Entity entity)
        {
            StartCoroutine(DespawnLogics());
        }
        
        private IEnumerator DespawnLogics()
        {
            Level.GetPlayer.coins.Increase(CoinsRewardStatParameter.Value);
            _animator.SetTrigger(DieAnimationTrigger);

            yield return new WaitForSecondsRealtime(1.5f);
            
            Destroy(gameObject);
        }
    }
}