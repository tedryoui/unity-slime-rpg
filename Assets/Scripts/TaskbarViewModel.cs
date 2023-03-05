using System;
using UnityEngine;

namespace SlimeRPG
{
    [Serializable]
    public class TaskbarViewModel
    {
        [SerializeField] private TaskbarView _view;

        public void UpdateCoins(float coins)
        {
            _view.coinsAmount.text = $"{coins:0.00}";
        }

        public void UpdateStage(string name)
        {
            _view.stageName.text = name;
        }
    }
}