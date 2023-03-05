using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SlimeRPG
{
    public class GuiHandler : MonoBehaviour
    {
        public TaskbarViewModel taskbarViewModel;
        public SlimeMenuViewModel slimeMenuViewModel;
        public PopUpsViewModel popUpsViewModel;
        public HealthBarsViewModel healthBarsViewModel;

        private void Start()
        {
            slimeMenuViewModel.Initialize();
        }
    }
}