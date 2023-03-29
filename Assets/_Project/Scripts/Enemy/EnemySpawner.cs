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

        public float spawnInterval;
        private TimedAction _timedAction;

        private void Start()
        {
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            StartSpawnEnemyLoop();
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
