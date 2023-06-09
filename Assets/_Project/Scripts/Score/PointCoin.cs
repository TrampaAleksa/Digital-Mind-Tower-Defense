using System;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class PointCoin : MonoBehaviour, IPickup
    {
        public int points = 1;
        public float secondsActive = 5f;

        public float radiusMultiplierInAndroid = 1.5f;

        private void Start()
        {
            gameObject.AddComponent<TimedAction>().StartTimedAction(DespawnCoin, secondsActive);

            if (Application.platform == RuntimePlatform.Android)
            {
                GetComponent<CapsuleCollider>().radius *= radiusMultiplierInAndroid;
            }
        }

        public void TriggerPickup()
        {
            Debug.Log($"Picked up coin and gained {points} points");
            ScoreHandler.Instance.AddScore(points);
            Destroy(gameObject);
        }

        private void DespawnCoin()
        {
            Debug.Log("Coin expired and despawned.");
            Destroy(gameObject);
        }
    }
}