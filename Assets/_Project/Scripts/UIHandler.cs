using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace com.digitalmind.towertest
{
    public class UIHandler : MonoBehaviour
    {
        private HealthUI _healthUI;

        private void Awake()
        {
            _healthUI = GetComponent<HealthUI>();
        }

        public void OnHealthChange(Health playerHealth, float newValue) =>
            _healthUI.OnHealthChange(playerHealth, newValue);
    }
}