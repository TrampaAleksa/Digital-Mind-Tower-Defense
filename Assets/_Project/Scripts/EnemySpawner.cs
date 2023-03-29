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

        public void SpawnEnemy()
        {
            var spawnPointIndex = Random.Range(0, spawnPoints.Length);
            var enemyIndex = Random.Range(0, enemyObjects.Length);

            Instantiate(enemyObjects[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SpawnEnemy();
            }
        }
    }
}
