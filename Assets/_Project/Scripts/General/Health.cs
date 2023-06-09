using System;
using UnityEngine;
using UnityEngine.Events;

namespace com.digitalmind.towertest
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float maxHealth;
        private float _currentHealth;
        
        public OnHealthChangedEvent onHealthChanged;
        public OnZeroHealthEvent onZeroHealth;

        private void Awake()
        {
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(float amount)
        {
            CurrentHealth -= amount;
            var mGameObject = gameObject;
            
            onHealthChanged.Invoke(this);

            if (CurrentHealth <= 0)
                onZeroHealth.Invoke(mGameObject);
        }

        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = Mathf.Clamp(value, 0, maxHealth);
        }

        public void SetMaxHealth(float value)
        {
            maxHealth = value;
            if (CurrentHealth > maxHealth)
                CurrentHealth = maxHealth;
        }

        public float MaxHealth => maxHealth;
    }

    
    
    [Serializable]
    public class OnZeroHealthEvent : UnityEvent<GameObject>
    {
    }
    
    [Serializable]
    public class OnHealthChangedEvent : UnityEvent<Health>
    {
    }
}