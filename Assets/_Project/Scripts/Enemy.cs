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

        private void Awake()
        {
            Init();
        }
        
        public void TakeDamage(float amount) => _enemyHealth.TakeDamage(amount);
        public void TriggerEnemyDeath() => _enemyDeath.TriggerEnemyDeath(this);


        private void Init()
        {
            gameObject.AddComponent<EnemyHitBox>().InjectEnemy(this);
            _enemyDeath = gameObject.GetComponent<EnemyDeath>();
            _enemyHealth = gameObject.GetComponent<EnemyHealth>();
        }
    }
}
