using System;
using Unity.VisualScripting;
using UnityEngine;

namespace SlimeRPG
{
    [Serializable]
    public class HealthPointsStat : IncreasableStatParameter
    {
        private UpgradableStatParameter _maxHealthPointsReference;
        private Entity _entityReference;
        
        private event Action<float, Vector3> UpdateHealthBar;
        private event Action RemoveHealthBar; 

        public HealthPointsStat(UpgradableStatParameter maxHealthPointsReference, Entity entityReference)
        {
            _maxHealthPointsReference = maxHealthPointsReference;
            _entityReference = entityReference;
            
            ForceSet(_maxHealthPointsReference.Value);
            Level.GetGui.healthBarsViewModel.CreateHealthBar(_entityReference.transform.position, ref UpdateHealthBar, ref RemoveHealthBar);
        }

        public override void Increase(float amount)
        {
            base.Increase(amount);

            if (Value <= 0)
            {
                _entityReference.Despawn?.Invoke(_entityReference);
                RemoveHealthBar?.Invoke();
            }
            else if (Value >= _maxHealthPointsReference.Value)
            {
                ForceSet(_maxHealthPointsReference.Value);
            }
        }

        public void Heal()
        {
            ForceSet(_maxHealthPointsReference.Value);
        }

        public void OnUpdateHealthBar()
        {
            UpdateHealthBar?.Invoke(Value / _maxHealthPointsReference.Value, _entityReference.transform.position);
        }
    }
}