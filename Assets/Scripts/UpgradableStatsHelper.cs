namespace SlimeRPG
{
    public static class UpgradableStatsHelper
    {
        public static UpgradableStatParameter GetAttackDamage()
        {
            var stat = new UpgradableStatParameter(
                (put) => put + 0.5f,
                (put) => put * 0.5f + put,
                2);
            stat.OnChange.AddListener(() => Level.GetGui.slimeMenuViewModel.UpdateAttackDamageView(stat));

            return stat;
        }

        public static UpgradableStatParameter GetHealthPoints()
        {
            var stat = new UpgradableStatParameter(
                (put) => put + 10,
                (put) => put * 0.7f + put,
                2
            );
            stat.OnChange.AddListener(() => Level.GetGui.slimeMenuViewModel.UpdateHealthPointsView(stat));

            return stat;
        }

        public static UpgradableStatParameter GetAttackDelay()
        {
            var stat = new UpgradableStatParameter(
                (put) => put - put * 0.25f,
                (put) => put * 1 + put,
                4
            );
            stat.OnChange.AddListener(() => Level.GetGui.slimeMenuViewModel.UpdateAttackSpeedView(stat));

            return stat;
        }

        public static UpgradableStatParameter GetProjectileSpeed()
        {
            var stat = new UpgradableStatParameter(
                (put) => put + put * 0.05f,
                (put) => put * 1.7f + put,
                3
            );
            stat.OnChange.AddListener(() => Level.GetGui.slimeMenuViewModel.UpdateProjectileSpeedView(stat));

            return stat;
        }
    }
}