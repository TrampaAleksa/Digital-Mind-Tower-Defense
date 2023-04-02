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

        private void Start()
        {
            _initialRotation = rotationObj.rotation;
            GetComponent<CapsuleCollider>().radius = range;
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
        }

        private void Update()
        {
            if (_enemiesInRange.Count != 0)
            {
                Quaternion lookOnLook =
                    Quaternion.LookRotation(_lockedOnEnemy.transform.position - rotationObj.position);

                rotationObj.rotation =
                    Quaternion.Slerp(rotationObj.rotation, lookOnLook, Time.deltaTime * rotSpeed);

                TryReloading();
                TryShooting();

            }

            if (_enemiesInRange.Count == 0)
            {
                rotationObj.rotation =
                    Quaternion.Slerp(rotationObj.rotation, _initialRotation, Time.deltaTime * rotSpeed);
            }
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
            
            var lookingAtEnemy = Vector3.Angle(rotationObj.forward,
                _lockedOnEnemy.transform.position - rotationObj.position) < lockOnAngle;

            if (lookingAtEnemy)
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
            _enemiesInRange.Remove(enemy);

            if (_enemiesInRange.Count != 0)
                _lockedOnEnemy = _enemiesInRange[0]; // grad the first available enemy in range
        }

        private void StopTrackingIfDestroyed(Enemy enemy)
        {
            if (!_enemiesInRange.Contains(enemy))
                return;

            _enemiesInRange.Remove(enemy);
            if (_enemiesInRange.Count != 0)
                _lockedOnEnemy = _enemiesInRange[0]; // grad the first available enemy in range
        }


        
        private void DebugTurret()
        {
            
            var debugAngle = false;
            var debugLooking = false;
            
            Debug.DrawRay(rotationObj.position, rotationObj.forward*50f, Color.red);
            
            if (_enemiesInRange.Count != 0)
            {
                Debug.DrawRay(rotationObj.position, _lockedOnEnemy.transform.position);
                
                if (debugAngle)
                    Debug.Log(Vector3.Angle(rotationObj.forward,
                        _lockedOnEnemy.transform.position - rotationObj.position));
                
                if (debugLooking)
                {
                    var lookingAtEnemy = Vector3.Angle(rotationObj.forward,
                        _lockedOnEnemy.transform.position - rotationObj.position) < lockOnAngle;
                    
                    Debug.Log("Looking: " + lookingAtEnemy);
                }
            }
        }
    }
}