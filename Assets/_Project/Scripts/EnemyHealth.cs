using System;
using UnityEngine;
using UnityEngine.Events;

namespace com.digitalmind.towertest
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHealth;
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
            Debug.Log($"Enemy took : {amount} damage", gameObject);
            Debug.Log($"Enemy health : {CurrentHealth}", gameObject);
           
            onHealthChanged.Invoke(gameObject, CurrentHealth);

            if (CurrentHealth <= 0)
                onZeroHealth.Invoke(gameObject);
        }

        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = Mathf.Clamp(value, 0, maxHealth);
        }
    }

    
    
    [Serializable]
    public class OnZeroHealthEvent : UnityEvent<GameObject>
    {
    }
    
    [Serializable]
    public class OnHealthChangedEvent : UnityEvent<GameObject, float>
    {
    }
}