using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace com.digitalmind.towertest
{
    public class GameUI : MonoBehaviour
    {
        private HealthUI _healthUI;
        private ScoreUI _scoreUI;

        private void Awake()
        {
            _healthUI = GetComponent<HealthUI>();
            _scoreUI = GetComponent<ScoreUI>();
        }

        public void OnHealthChange(Health playerHealth) =>
            _healthUI.OnHealthChange(playerHealth);

        public void OnScoreChange(int newValue)
            => _scoreUI.OnScoreChange(newValue);
    }
}