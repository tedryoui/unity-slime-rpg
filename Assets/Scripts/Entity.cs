using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SlimeRPG
{
    public class Entity : MonoBehaviour, IDamageable
    {
        public IState CrrState;
        [HideInInspector] public Entity Target;

        protected HealthPointsStat HealthPointsStat;
        public UpgradableStatParameter maxHealthPoints;
        public UpgradableStatParameter attackDamage;

        public Action<Entity> Despawn;
        
        protected virtual void Start()
        {
            HealthPointsStat = new HealthPointsStat(maxHealthPoints, this);
        }
        
        protected virtual void Update()
        {
            HealthPointsStat.OnUpdateHealthBar();
            
            CrrState.DoState();
        }

        public void SetState(IState state)
        {
            CrrState = state;
        }

        public void Heal() => HealthPointsStat.Heal();

        public void ApplyDamage(float amount)
        {
            HealthPointsStat.Increase(amount);
            Level.GetGui.popUpsViewModel.ShowPopUp(transform.position, $"{amount:0}");
        }
    }
}