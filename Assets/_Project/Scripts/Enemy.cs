using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class Enemy : MonoBehaviour
    {
        public float maxHealth;
        
        private float _currentHealth;

        private void Awake()
        {
        }
        
        public void TakeDamage(float amount)
        {
            CurrentHealth -= amount;
            Debug.Log($"Enemy took : {amount} damage");
        }
        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = Mathf.Clamp(_currentHealth - value, 0, maxHealth);
        }
    }
}
