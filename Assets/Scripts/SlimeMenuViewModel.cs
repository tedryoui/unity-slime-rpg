using System;
using UnityEngine;

namespace SlimeRPG
{
    [Serializable]
    public class SlimeMenuViewModel
    {
        [SerializeField] private SlimeMenuView _view;

        public event Action OnAttackUpgrade;
        public event Action OnHealthPointsUpgrade;
        public event Action OnAttackSpeedUpgrade;
        public event Action OnProjectileSpeedUpgrade;

        public void Initialize()
        {
            _view.AttackUpgrade += () => OnAttackUpgrade?.Invoke();
            _view.HealthPointsUpgrade += () => OnHealthPointsUpgrade?.Invoke();
            _view.AttackSpeedUpgrade += () => OnAttackSpeedUpgrade?.Invoke();
            _view.ProjectileSpeedUpgrade += () => OnProjectileSpeedUpgrade?.Invoke();
        }

        public void UpdateHealthPointsView(UpgradableStatParameter healthPoints)
        {
            _view.healthPointsAmount.text = $"{healthPoints.Value:0.00}";
            _view.healthPointsUpgradeCost.text = $"{healthPoints.UpgradeCost:0.00}";
        }

        public void UpdateAttackDamageView(UpgradableStatParameter attackDamage)
        {
            _view.attackDamageAmount.text = $"{attackDamage.Value:0.00}";
            _view.attackDamageUpgradeCost.text = $"{attackDamage.UpgradeCost:0.00}";
        }
        
        public void UpdateAttackSpeedView(UpgradableStatParameter attackSpeed)
        {
            _view.attackSpeedAmount.text = $"{attackSpeed.Value:0.00}";
            _view.attackSpeedUpgradeCost.text = $"{attackSpeed.UpgradeCost:0.00}";
        }
        
        public void UpdateProjectileSpeedView(UpgradableStatParameter projectileSpeed)
        {
            _view.projectileSpeedAmount.text = $"{projectileSpeed.Value:0.00}";
            _view.projectileSpeedUpgradeCost.text = $"{projectileSpeed.UpgradeCost:0.00}";
        }
    }
}