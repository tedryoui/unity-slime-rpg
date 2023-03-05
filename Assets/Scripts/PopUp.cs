using System;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeRPG
{
    public class PopUp : MonoBehaviour
    {
        private bool _isAnimated = false;
        private float _timePast;

        [SerializeField] private Text _text;
        public float speed;
        public float lifeTime;

        [Tooltip("Animations Curves Evaluate for 1.0s")]
        public AnimationCurve slideCurve;
        public AnimationCurve opacityCurve;

        private void Start()
        {
            _timePast = 0;
            
            UpdateSlide();
            UpdateColor();
        }

        private void Update()
        {
            ProcessPopup();
        }

        private void ProcessPopup()
        {
            if (_isAnimated)
            {
                if (_timePast >= lifeTime)
                {
                    Destroy(gameObject);
                    return;
                }
                
                _timePast += Time.deltaTime;

                UpdateSlide();
                UpdateColor();
            }
        }

        private void UpdateSlide()
        {
            var offset = Vector3.zero;
            offset.y = slideCurve.Evaluate(_timePast) * speed * Time.deltaTime;
            transform.position += offset;
        }

        private void UpdateColor()
        {
            var crrColor = _text.color;
            crrColor.a = opacityCurve.Evaluate(_timePast);
            _text.color = crrColor;
        }

        public void Animate() => _isAnimated = true;

        public void SetText(string value) => _text.text = value;
    }
}