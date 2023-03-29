using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    [RequireComponent(typeof(EnemyDeath))]
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        private EnemyDeath _enemyDeath;
        private Health _health;
        private EnemyNavigation _enemyNavigation;
        private EnemyBehaviour _enemyBehaviour;

        private void Awake()
        {
            Init();
        }
        
        public void TakeDamage(float amount)
            => _health.TakeDamage(amount);
        public void TriggerEnemyDeath()
            => _enemyDeath.TriggerEnemyDeath(this);
        public void SetSpeed(float speed)
            => _enemyNavigation.SetSpeed(speed);
        public void SetStoppingDistance(float stoppingDistance) =>
            _enemyNavigation.SetStoppingDistance(stoppingDistance);
        public void SetMaxHealth(float maxHealth)
            => _health.SetMaxHealth(maxHealth);

        private void Init()
        {
            gameObject.AddComponent<EnemyHitBox>().InjectEnemy(this);
            _enemyDeath = gameObject.GetComponent<EnemyDeath>();
            _health = gameObject.GetComponent<Health>();
            _enemyNavigation = gameObject.GetComponent<EnemyNavigation>();
            _enemyBehaviour = gameObject.GetComponent<EnemyBehaviour>();
            
            //TODO - optimize finding player game object
            _enemyNavigation.StartNavigation(GameObject.FindWithTag("Player").transform);
            
            _enemyBehaviour.SetUpBehaviour(this);
        }
    }
}
