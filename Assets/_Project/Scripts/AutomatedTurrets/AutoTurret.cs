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
        public Enemy LockedOnEnemy { get; private set; }

        private Quaternion _initialRotation;

        private TimedAction _timedAction;
        private bool isShotReady;
        private bool isReloading;

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


        public Quaternion TurretRotation { get => rotationObj.rotation; private set => rotationObj.rotation = value; }
        public Vector3 DirectionToLockedOnEnemy => LockedOnEnemy.transform.position - rotationObj.position;
        public Quaternion RotationToLockedOnEnemy => Quaternion.LookRotation(DirectionToLockedOnEnemy);
        public bool IsLookingAtEnemy => Vector3.Angle(rotationObj.forward, DirectionToLockedOnEnemy) < lockOnAngle;
        public bool HasEnemiesInRange => _enemiesInRange.Count != 0;

    }
}