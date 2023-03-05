using System;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace SlimeRPG
{
    [Serializable]
    public class UpgradableStatParameter : StatParameter
    {
        private readonly Func<float, float> _upgradeFormula;
        private readonly Func<float, float> _upgradeCostFormula;

        private float cost;
        
        public float UpgradeCost => _upgradeCostFormula.Invoke(cost);
        public float UpgradeValue => _upgradeFormula.Invoke(Value);
        
        public UpgradableStatParameter(Func<float, float> upgradeFormula, Func<float, float> upgradeCostFormula, float baseCost)
        {
            if (OnChange == null) OnChange = new UnityEvent();
            
            _upgradeCostFormula = upgradeCostFormula;
            _upgradeFormula = upgradeFormula;

            cost = baseCost;
        }

        public void Upgrade(IncreasableStatParameter coinsReference)
        {
            if (coinsReference.Value >= UpgradeCost)
            {
                coinsReference.Increase(-UpgradeCost);
                _value = UpgradeValue;
                cost = UpgradeCost;
                
                OnChange?.Invoke();
            }
        }
    }
}