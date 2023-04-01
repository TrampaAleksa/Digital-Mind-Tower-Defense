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
        
        public float range = 1.8f;
        public float rotSpeed = 1f;

        private List<Enemy> _enemiesInRange = new List<Enemy>();
        private Enemy _lockedOnEnemy;

        private Quaternion _initialRotation;

        private void Start()
        {
            _initialRotation = rotationObj.rotation;
        }

        private void Update()
        {
            if (_enemiesInRange.Count != 0)
            {
                Quaternion lookOnLook =
                    Quaternion.LookRotation(_lockedOnEnemy.transform.position - rotationObj.position);
            
                rotationObj.rotation =
                    Quaternion.Slerp(rotationObj.rotation, lookOnLook, Time.deltaTime * rotSpeed);
            }
            
            if (_enemiesInRange.Count == 0)
            {
                rotationObj.rotation =
                    Quaternion.Slerp(rotationObj.rotation, _initialRotation, Time.deltaTime * rotSpeed);
            }
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
    }
}