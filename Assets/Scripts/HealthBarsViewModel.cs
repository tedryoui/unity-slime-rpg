using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace SlimeRPG
{
    [Serializable]
    public class HealthBarsViewModel
    {
        [SerializeField] private HealthBarsView _view;

        [SerializeField] private HealthBar _healthBarPrefab;
        [SerializeField] private float yOffset;
        
        public void CreateHealthBar(Vector3 worldCoordinates, ref Action<float, Vector3> updateAction, ref Action removeHealthBar)
        {
            var screenCoordinates = Camera.main.WorldToScreenPoint(worldCoordinates);

            HealthBar healthBar = Object.Instantiate(_healthBarPrefab, screenCoordinates, Quaternion.identity, _view.transform);

            GameObject gameObject = healthBar.gameObject;
            updateAction += (value, worldCoordinates) => UpdateHealthBar(healthBar.inner, value, worldCoordinates);
            removeHealthBar += () => Object.Destroy(gameObject);
            
            Object.Destroy(healthBar);
        }

        public void UpdateHealthBar(Image image, float value, Vector3 worldCoordinates)
        {
            if (image == null) return;
            
            var screenCoordinates = Camera.main.WorldToScreenPoint(worldCoordinates);
            screenCoordinates.y += yOffset;
            
            image.transform.parent.position = screenCoordinates;
            image.fillAmount = value;
        }
    }
}