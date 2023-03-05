using UnityEngine;

namespace SlimeRPG
{
    public static class DataSaver
    {
        private const string Player_CoinsAmountStatName = "Player_CoinsAmount";
        
        private const string Slime_AttackDamageStatName = "Slime_AttackDamage";
        private const string Slime_HealthPointsStatName = "Slime_HealthPoints";
        private const string Slime_AttackDelayStatName = "Slime_AttackDelay";
        private const string Slime_ProjectileSpeedStatName = "Slime_ProjectileSpeed";

        private const string Stager_StageNumber = "Stager_StageNumber";

        public static void LoadFromDisk(this Slime slime)
        {
            float floatValue;
            
            floatValue = (PlayerPrefs.HasKey(Slime_HealthPointsStatName)) ?
                PlayerPrefs.GetFloat(Slime_HealthPointsStatName) : 1;
            slime.maxHealthPoints.ForceSet(floatValue);
            
            floatValue = (PlayerPrefs.HasKey(Slime_AttackDamageStatName)) ?
                PlayerPrefs.GetFloat(Slime_AttackDamageStatName) : 1;
            slime.attackDamage.ForceSet(floatValue);
            
            floatValue = (PlayerPrefs.HasKey(Slime_AttackDelayStatName)) ?
                PlayerPrefs.GetFloat(Slime_AttackDelayStatName) : 4;
            slime.AttackDelayStatParameter.ForceSet(floatValue);
            
            floatValue = (PlayerPrefs.HasKey(Slime_ProjectileSpeedStatName)) ?
                PlayerPrefs.GetFloat(Slime_ProjectileSpeedStatName) : 1;
            slime.ProjectileSpeedStatParameter.ForceSet(floatValue);
        }

        public static void SaveToDisk(this Slime slime)
        {
            PlayerPrefs.SetFloat(Slime_AttackDamageStatName, slime.attackDamage.Value);
            PlayerPrefs.SetFloat(Slime_HealthPointsStatName, slime.maxHealthPoints.Value);
            PlayerPrefs.SetFloat(Slime_AttackDelayStatName, slime.AttackDelayStatParameter.Value);
            PlayerPrefs.SetFloat(Slime_ProjectileSpeedStatName, slime.ProjectileSpeedStatParameter.Value);
            
            PlayerPrefs.Save();
        }

        public static void LoadFromDisk(this Player player)
        {
            float floatValue;
            
            floatValue = (PlayerPrefs.HasKey(Player_CoinsAmountStatName)) ?
                PlayerPrefs.GetFloat(Player_CoinsAmountStatName) : 0;
            player.coins.ForceSet(floatValue);
        }

        public static void SaveToDisk(this Player player)
        {
            PlayerPrefs.SetFloat(Player_CoinsAmountStatName, player.coins.Value);
            
            PlayerPrefs.Save();
        }

        public static void LoadFromDisk(this Stager stager)
        {
            var number = (PlayerPrefs.HasKey(Stager_StageNumber)) ? 
                PlayerPrefs.GetInt(Stager_StageNumber) : 0;

            stager.crrPresetNumber = number;
        }

        public static void SaveToDisk(this Stager stager)
        {
            PlayerPrefs.SetInt(Stager_StageNumber, stager.crrPresetNumber);
            
            PlayerPrefs.Save();
        } 
    }
}