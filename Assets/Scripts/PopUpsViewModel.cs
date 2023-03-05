using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SlimeRPG
{
    [Serializable]
    public class PopUpsViewModel
    {
        [SerializeField] private PopUpsView _view;

        [SerializeField] private PopUp _popUpPrefab;

        public void ShowPopUp(Vector3 worldCoordinates, string value)
        {
            var screenCoordinates = Camera.main.WorldToScreenPoint(worldCoordinates);

            PopUp popUp = Object.Instantiate(_popUpPrefab, screenCoordinates, Quaternion.identity, _view.transform);
            popUp.Animate();
            popUp.SetText(value);
        }
    }
}