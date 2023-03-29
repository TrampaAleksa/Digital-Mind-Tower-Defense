using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    [RequireComponent(typeof(EnemyDeath))]
    public class Enemy : MonoBehaviour
    {
        private EnemyDeath _enemyDeath;
        
        public float maxHealth;
        private float _currentHealth;

        private void Awake()
        {
            gameObject.AddComponent<EnemyHitBox>().InjectEnemy(this);
            _enemyDeath = gameObject.GetComponent<EnemyDeath>();
            CurrentHealth = maxHealth;
        }
        
        public void TakeDamage(float amount)
        {
            CurrentHealth -= amount;
            Debug.Log($"Enemy took : {amount} damage");
            Debug.Log($"Current enemy health is {CurrentHealth}");

            if (CurrentHealth <= 0)
                _enemyDeath.TriggerEnemyDeath(this);
        }
        
        
        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = Mathf.Clamp(value, 0, maxHealth);
        }
    }
}
