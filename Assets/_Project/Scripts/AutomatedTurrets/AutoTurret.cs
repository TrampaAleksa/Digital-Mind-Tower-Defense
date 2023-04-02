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
        public GameObject projectile;
        public Transform rotationObj;
        public Transform gunTip;

        public float range = 1.8f;
        public float rotSpeed = 1f;
        public float lockOnAngle = 2.5f; 

        private List<Enemy> _enemiesInRange = new List<Enemy>();
        private Enemy _lockedOnEnemy;

        private Quaternion _initialRotation;

        private TimedAction _timedAction;
        private bool isShotReady;
        private bool isReloading;
        public Quaternion TurretRotation { get => rotationObj.rotation; private set => rotationObj.rotation = value; }

        private void Start()
        {
            _initialRotation = TurretRotation;
            GetComponent<CapsuleCollider>().radius = range;
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
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
            TurretRotation =
                Quaternion.Slerp(TurretRotation, _initialRotation, Time.deltaTime * rotSpeed);
        }

        private void HandleLockOnEnemy()
        {
            TurretRotation =
                Quaternion.Slerp(TurretRotation, RotationToLockedOnEnemy, Time.deltaTime * rotSpeed);

            TryReloading();
            TryShooting();
        }

        public Vector3 DirectionToLockedOnEnemy => _lockedOnEnemy.transform.position - rotationObj.position;
        public Quaternion RotationToLockedOnEnemy => Quaternion.LookRotation(DirectionToLockedOnEnemy);
        public bool IsLookingAtEnemy => Vector3.Angle(rotationObj.forward, DirectionToLockedOnEnemy) < lockOnAngle;
        public bool HasEnemiesInRange => _enemiesInRange.Count != 0;

        private void TryReloading()
        {
            if (!isShotReady && !isReloading)
                StartReload();
        }

        private void StartReload()
        {
            isReloading = true;
            _timedAction.StartTimedAction(FinishReload, 0.5f);
        }

        private void FinishReload()
        {
            isShotReady = true;
            isReloading = false;
        }

        private void TryShooting()
        {
            if (!isShotReady)
                return;
            
            if (IsLookingAtEnemy)
                Shoot();
        }

        private void Shoot()
        {
            isShotReady = false;
            Instantiate(projectile, gunTip.position, gunTip.rotation);
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
                _lockedOnEnemy = enemy;
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
                _lockedOnEnemy = _enemiesInRange[0]; // grad the first available enemy in range
        }

        private void StopTrackingIfDestroyed(Enemy enemy)
        {
            if (!_enemiesInRange.Contains(enemy))
                return;

            _enemiesInRange.Remove(enemy);
            if (HasEnemiesInRange)
                _lockedOnEnemy = _enemiesInRange[0]; // grad the first available enemy in range
        }


        
        private void DebugTurret()
        {
            
            var debugAngle = false;
            var debugLooking = false;
            
            Debug.DrawRay(rotationObj.position, rotationObj.forward*50f, Color.red);
            
            if (HasEnemiesInRange)
            {
                Debug.DrawRay(rotationObj.position, _lockedOnEnemy.transform.position);
                
                if (debugAngle)
                    Debug.Log(Vector3.Angle(rotationObj.forward,
                        DirectionToLockedOnEnemy));
                
                if (debugLooking)
                    Debug.Log("Looking: " + IsLookingAtEnemy);
            }
        }
    }
}