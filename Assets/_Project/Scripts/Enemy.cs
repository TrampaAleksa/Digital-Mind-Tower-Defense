using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    [RequireComponent(typeof(EnemyDeath))]
    [RequireComponent(typeof(EnemyHealth))]
    public class Enemy : MonoBehaviour
    {
        private EnemyDeath _enemyDeath;
        private EnemyHealth _enemyHealth;
        private EnemyNavigation _enemyNavigation;
        private EnemyBehaviour _enemyBehaviour;

        private void Awake()
        {
            Init();
        }
        
        public void TakeDamage(float amount)
            => _enemyHealth.TakeDamage(amount);
        public void TriggerEnemyDeath()
            => _enemyDeath.TriggerEnemyDeath(this);
        public void SetSpeed(float speed)
            => _enemyNavigation.SetSpeed(speed);
        public void SetStoppingDistance(float stoppingDistance) =>
            _enemyNavigation.SetStoppingDistance(stoppingDistance);
        public void SetMaxHealth(float maxHealth)
            => _enemyHealth.SetMaxHealth(maxHealth);

        private void Init()
        {
            gameObject.AddComponent<EnemyHitBox>().InjectEnemy(this);
            _enemyDeath = gameObject.GetComponent<EnemyDeath>();
            _enemyHealth = gameObject.GetComponent<EnemyHealth>();
            _enemyNavigation = gameObject.GetComponent<EnemyNavigation>();
            _enemyBehaviour = gameObject.GetComponent<EnemyBehaviour>();
            
            //TODO - optimize finding player game object
            _enemyNavigation.StartNavigation(GameObject.FindWithTag("Player").transform);
            
            _enemyBehaviour.SetUpBehaviour(this);
        }
    }
}
