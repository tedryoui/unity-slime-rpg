using System;
using UnityEngine;

namespace SlimeRPG
{
    public class Player : MonoBehaviour
    {
        public Slime slime;
        
        public IncreasableStatParameter coins;

        private void Start()
        {
            Level.GetGui.slimeMenuViewModel.OnAttackUpgrade += () => slime.attackDamage.Upgrade(coins);
            Level.GetGui.slimeMenuViewModel.OnHealthPointsUpgrade += () => slime.maxHealthPoints.Upgrade(coins);
            Level.GetGui.slimeMenuViewModel.OnAttackSpeedUpgrade += () => slime.AttackDelayStatParameter.Upgrade(coins);
            Level.GetGui.slimeMenuViewModel.OnProjectileSpeedUpgrade += () => slime.ProjectileSpeedStatParameter.Upgrade(coins);
            
            coins.OnChange.AddListener(UpdateCoinsText);
            
            this.LoadFromDisk();
        }

        public void UpdateCoinsText()
        {
            Level.GetGui.taskbarViewModel.UpdateCoins(coins.Value);
        }
    }
}