using System;

namespace SlimeRPG
{
    [Serializable]
    public class IncreasableStatParameter : StatParameter
    {
        public virtual void Increase(float amount)
        {
            _value += amount;
            
            OnChange?.Invoke();
        }
    }
}