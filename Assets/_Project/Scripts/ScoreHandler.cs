using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace com.digitalmind.towertest
{
    public class ScoreHandler : MonoBehaviour
    {
        public OnScoreChangedEvent onScoreChangedEvent;

        public static ScoreHandler Instance;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public int CurrentScore { get; set; }

        public void AddScore(int amount)
        {
            CurrentScore += amount;
            onScoreChangedEvent.Invoke(CurrentScore);
            Debug.Log($"Gained {amount} score");
        }
    }
    
    [Serializable]
    public class OnScoreChangedEvent : UnityEvent<float>{}
}
