using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    [RequireComponent(typeof(OnEnemyDeathEvents))]
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        private OnEnemyDeathEvents _onEnemyDeathEvents;
        private Health _health;
        private EnemyNavigation _enemyNavigation;
        private EnemyBehaviour _enemyBehaviour;

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            _enemyNavigation.StartNavigation(Player.Find.transform);
            _enemyBehaviour.SetUpBehaviour(this);
        }

        public void TakeDamage(float amount)
            => _health.TakeDamage(amount);
        // public void TriggerEnemyDeath()
        //     => _onEnemyDeathEvents.TriggerEnemyDeath(this);
        public void SetSpeed(float speed)
            => _enemyNavigation.SetSpeed(speed);
        public void SetStoppingDistance(float stoppingDistance) =>
            _enemyNavigation.SetStoppingDistance(stoppingDistance);
        public void SetMaxHealth(float maxHealth)
            => _health.SetMaxHealth(maxHealth);

        private void Init()
        {
            gameObject.AddComponent<EnemyHitBox>().InjectEnemy(this);
            // _onEnemyDeathEvents = gameObject.GetComponent<OnEnemyDeathEvents>();
            _health = gameObject.GetComponent<Health>();
            _enemyNavigation = gameObject.GetComponent<EnemyNavigation>();
            _enemyBehaviour = gameObject.GetComponent<EnemyBehaviour>();
            
        }
    }
}
