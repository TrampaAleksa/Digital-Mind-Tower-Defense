using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.digitalmind.towertest
{
    
    //TODO - There is a small chance of the on destroyed callback throwing an error, use instanceId of enemy instead of enemy
    public class AutoTurret : MonoBehaviour
    {
        private AutoTurretGun _turretGun;
        private AutoTurretRotation _turretRotation;
        
        public float range = 1.8f;

        private List<Enemy> _enemiesInRange = new List<Enemy>();

        private void Start()
        {
            GetComponent<CapsuleCollider>().radius = range;
            _turretGun = GetComponent<AutoTurretGun>();
            _turretRotation = GetComponent<AutoTurretRotation>();
        }

        private void Update()
        {
            if (HasEnemiesInRange)
                HandleLockOnEnemy();
            else 
                HandleDefaultState();
        }

        private void HandleDefaultState()
        {
            _turretRotation.RotateToInitialPosition();
            _turretGun.TryReloading();
        }

        private void HandleLockOnEnemy()
        {
            _turretRotation.RotateToTarget(LockedOnEnemy.transform);
            _turretGun.TryReloading();
            _turretGun.TryShooting(this);
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
            enemy.onDestroyCallback += StopTrackingIfDestroyed;
            _enemiesInRange.Add(enemy);

            if (_enemiesInRange.Count == 1)
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
                LockedOnEnemy = _enemiesInRange[0]; // grad the first available enemy in range
        }

        private void StopTrackingIfDestroyed(Enemy enemy)
        {
            if (!_enemiesInRange.Contains(enemy))
                return;

            _enemiesInRange.Remove(enemy);
            if (HasEnemiesInRange)
                LockedOnEnemy = _enemiesInRange[0]; // grad the first available enemy in range
        }


        public Enemy LockedOnEnemy { get; private set; }
        public Vector3 DirectionToLockedOnEnemy => _turretRotation.DirectionToTarget;
        public bool IsLookingAtEnemy => _turretRotation.IsLookingAtTarget;
        public bool HasEnemiesInRange => _enemiesInRange.Count != 0;
        public Transform RotationObject => _turretRotation.rotationObj;

    }
}