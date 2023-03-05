using System;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeRPG
{
    public class SlimeMenuView : MonoBehaviour
    {
        public Text attackDamageAmount;
        public Text attackDamageUpgradeCost;

        public Text healthPointsAmount;
        public Text healthPointsUpgradeCost;
        
        public Text attackSpeedAmount;
        public Text attackSpeedUpgradeCost;
        
        public Text projectileSpeedAmount;
        public Text projectileSpeedUpgradeCost;
        
        public event Action AttackUpgrade;
        public event Action HealthPointsUpgrade;
        public event Action AttackSpeedUpgrade;
        public event Action ProjectileSpeedUpgrade;

        public void OnAttackUpgrade()
        {
            AttackUpgrade?.Invoke();
        }

        public void OnHealthPointsUpgrade()
        {
            HealthPointsUpgrade?.Invoke();
        }

        public void OnAttackSpeedUpgrade()
        {
            AttackSpeedUpgrade?.Invoke();
        }

        public void OnProjectileSpeedUpgrade()
        {
            ProjectileSpeedUpgrade?.Invoke();
        }
    }
}