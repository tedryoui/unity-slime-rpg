using System;
using UnityEngine;
using UnityEngine.Events;

namespace SlimeRPG
{
    [Serializable]
    public class StatParameter
    {
        [SerializeField] protected float _value;

        public float Value => _value;
        
        [HideInInspector] public UnityEvent OnChange;

        public StatParameter()
        {
            _value = 0;
        }
        
        public StatParameter(float value)
        {
            _value = value;
        }

        public void ForceSet(float value)
        {
            _value = value;
            OnChange?.Invoke();
        }
    }
}