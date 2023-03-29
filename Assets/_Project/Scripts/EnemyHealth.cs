using System;
using UnityEngine;
using UnityEngine.Events;

namespace com.digitalmind.towertest
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHealth;
        private float _currentHealth;
        
        public UnityEvent<GameObject, float> onHealthChanged;
        public UnityEvent<GameObject> onZeroHealth;

        private void Start()
        {
            onHealthChanged.AddListener(
                (enemy, currentHealth)
                    =>  Debug.Log($"{enemy.name} health changed to: {currentHealth}"));
            onZeroHealth.AddListener(
                (enemy)
                    =>  Debug.Log($"{enemy.name} has died!"));
        }

        public void TakeDamage(float amount)
        {
            CurrentHealth -= amount;
            Debug.Log($"Enemy took : {amount} damage");
           
            
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
}