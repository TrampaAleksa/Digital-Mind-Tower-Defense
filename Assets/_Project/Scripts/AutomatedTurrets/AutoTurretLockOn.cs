using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurretLockOn : MonoBehaviour
    {
        public float range = 35f;

        private List<Enemy> _enemiesInRange = new List<Enemy>();

        private void Start()
        {
            GetComponent<CapsuleCollider>().radius = range;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy"))
                return;

            var enemy = other.GetComponent<EnemyHitBox>().Enemy;
            HandleEnemyEnteredRange(enemy);
        }

        private void HandleEnemyEnteredRange(Enemy enemy)
        {
            enemy.onDestroyCallback += StopTrackingIfDestroyed; // to prevent null references
            _enemiesInRange.Add(enemy);

            var isFirstEnemy = _enemiesInRange.Count == 1;
            if (isFirstEnemy)
                LockedOnEnemy = enemy;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Enemy"))
                return;

            var enemy = other.GetComponent<EnemyHitBox>().Enemy;
            HandleEnemyExitedRange(enemy);
        }

        private void HandleEnemyExitedRange(Enemy enemy)
        {
            _enemiesInRange.Remove(enemy);

            if (HasEnemiesInRange)
                LockToNextEnemy();
        }

        private void StopTrackingIfDestroyed(Enemy enemy)
        {
            if (!_enemiesInRange.Contains(enemy))
                return;

            _enemiesInRange.Remove(enemy);
            if (HasEnemiesInRange)
                LockToNextEnemy();
        }


        public void LockToNextEnemy()
            => LockedOnEnemy = _enemiesInRange[0]; 

        public Enemy LockedOnEnemy { get; private set; }
        public bool HasEnemiesInRange => _enemiesInRange.Count != 0;
    }
}