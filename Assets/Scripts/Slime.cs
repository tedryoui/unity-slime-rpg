using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeRPG
{
    public class Slime : Entity
    {
        [SerializeField] private Animator _animator;
        
        public StatParameter SpeedStatParameter;
        public StatParameter AttackDistanceStatParameter;
        public Projectile Projectile;
        
        public UpgradableStatParameter AttackDelayStatParameter;
        public UpgradableStatParameter ProjectileSpeedStatParameter;
        
        private static readonly int DieAnimationTrigger = Animator.StringToHash("Die");

        public State<Slime> IdleState { get; private set; }
        public State<Slime> MoveState { get; private set; }
        public State<Slime> AttackState { get; private set; }
        public Animator GetAnimator => _animator;

        protected override void Start()
        {
            Despawn += OnDespawn;
            
            IdleState = new SlimeIdleState(this);
            AttackState = new SlimeAttackState(this);
            MoveState = new SlimeMoveState(this);
            CrrState = IdleState;
            
            attackDamage = UpgradableStatsHelper.GetAttackDamage();
            maxHealthPoints = UpgradableStatsHelper.GetHealthPoints();
            AttackDelayStatParameter = UpgradableStatsHelper.GetAttackDelay();
            ProjectileSpeedStatParameter = UpgradableStatsHelper.GetProjectileSpeed();
            
            this.LoadFromDisk();
            base.Start();
        }

        private void OnDespawn(Entity entity)
        {
            Level.GetPlayer.StartCoroutine(DespawnLogics());
        }

        private IEnumerator DespawnLogics()
        {
            _animator.SetTrigger(DieAnimationTrigger);
            Destroy(this);

            yield return new WaitForSecondsRealtime(2.5f);
            
            Level.ReloadScene();
        }
    }
}