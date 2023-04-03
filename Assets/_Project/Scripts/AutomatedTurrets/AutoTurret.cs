using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurret : MonoBehaviour
    {
        private AutoTurretGun _turretGun;
        private AutoTurretRotation _turretRotation;
        private AutoTurretLockOn _turretLockOn;
        
        private void Start()
        {
            _turretGun = GetComponent<AutoTurretGun>();
            _turretRotation = GetComponent<AutoTurretRotation>();
            _turretLockOn = GetComponent<AutoTurretLockOn>();
        }

        private void Update()
        {
            if (HasEnemiesInRange)
                HandleLockOnEnemy();
            else 
                HandleDefaultState();
        }

        private void HandleLockOnEnemy()
        {
            _turretRotation.RotateToTarget(LockedOnEnemy.transform);
            _turretGun.TryReloading();
            _turretGun.TryShooting(this);
        }

        private void HandleDefaultState()
        {
            _turretRotation.RotateToInitialPosition();
            _turretGun.TryReloading();
        }

        public bool IsLookingAtEnemy => _turretRotation.IsLookingAtTarget;
        private Enemy LockedOnEnemy => _turretLockOn.LockedOnEnemy;
        private bool HasEnemiesInRange => _turretLockOn.HasEnemiesInRange;

    }
}