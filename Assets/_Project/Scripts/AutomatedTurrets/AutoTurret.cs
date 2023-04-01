using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.digitalmind.towertest
{
    public class AutoTurret : MonoBehaviour
    {
        public GameObject projectile;

        private List<Enemy> _enemiesInRange = new List<Enemy>();
        private Enemy _lockedOnEnemy;

        private void Update()
        {
            foreach (var enemy in _enemiesInRange)
            {
                Debug.Log("Enemies in range: " + _enemiesInRange.Count);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy"))
                return;
            
            var enemy = other.GetComponent<EnemyHitBox>().Enemy;
            _enemiesInRange.Add(enemy);

            if (_enemiesInRange.Count != 0)
                _lockedOnEnemy = enemy;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Enemy")) 
                return;
            
            var enemy = other.GetComponent<EnemyHitBox>().Enemy;
            _enemiesInRange.Remove(enemy);

            if (_enemiesInRange.Count != 0)
                _lockedOnEnemy = _enemiesInRange[0]; // grad the first available enemy in range
        }
    }
}