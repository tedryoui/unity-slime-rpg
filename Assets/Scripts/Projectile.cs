using UnityEngine;

namespace SlimeRPG
{
    [CreateAssetMenu(fileName = "DefaultProjectile", menuName = "Projectiles/Default", order = 0)]
    public class Projectile : ScriptableObject
    {
        public AnimationCurve flyCurve;
        public GameObject prefab;
    }
}