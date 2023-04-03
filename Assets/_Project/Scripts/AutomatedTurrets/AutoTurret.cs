using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurret : MonoBehaviour
    {
        private AutoTurretRotation _turretRotation;
        private AutoTurretLockOn _turretLockOn;
        
        private void Start()
        {
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
        }

        private void HandleDefaultState()
        {
            _turretRotation.RotateToInitialPosition();
        }

        private Enemy LockedOnEnemy => _turretLockOn.LockedOnEnemy;
        private bool HasEnemiesInRange => _turretLockOn.HasEnemiesInRange;

    }
}