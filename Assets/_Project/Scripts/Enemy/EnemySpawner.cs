using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.digitalmind.towertest
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject[] enemyObjects;
        public Transform[] spawnPoints;

        public float spawnInterval = 5f;
        private TimedAction _timedAction;
        private TimedAction _decrementTimedAction;
        
        public float decrementInterval = 8f;
        public float spawnSpeedDecrement = 0.5f;
        public float lowestSpawnSpeed = 0.4f;

        private void Start()
        {
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            _decrementTimedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            StartSpawnEnemyLoop();
            StartDecrementLoop();
        }

        private void StartDecrementLoop()
        {
            spawnInterval -= spawnSpeedDecrement;
            spawnInterval = Mathf.Clamp(spawnInterval, lowestSpawnSpeed, float.MaxValue);
            _decrementTimedAction.StartTimedAction(StartDecrementLoop, decrementInterval);
        }

        private void StartSpawnEnemyLoop()
        {
            _timedAction.StartTimedAction(StartSpawnEnemyLoop, spawnInterval);
            SpawnEnemy();
        }
        private Enemy SpawnEnemy()
        {
            var spawnPointIndex = Random.Range(0, spawnPoints.Length);
            var enemyIndex = Random.Range(0, enemyObjects.Length);

            return Instantiate(
                enemyObjects[enemyIndex],
                spawnPoints[spawnPointIndex].position,
                spawnPoints[spawnPointIndex].rotation)
                .GetComponent<Enemy>();
        }
    }
}
