using System.Collections.Generic;
using UnityEngine;

namespace SlimeRPG
{
    [CreateAssetMenu(fileName = "StagePreset", menuName = "Stages/Preset", order = 0)]
    public class StagePreset : ScriptableObject
    {
        public List<Enemy> Enemies;
    }
}