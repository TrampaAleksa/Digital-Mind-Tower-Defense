using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace com.digitalmind.towertest
{
    public class UIHandler : MonoBehaviour
    {
        public Image[] lives;
        public LifeColors colors; // TODO - Use single struct with the three colors predefined inside
        
        private const int HighHealthPercentage = 60;
        private const int LowHealthPercentage = 20;

        public void Start()
        {
            InitLivesDisplay();
            SetLifeColor(colors.highColor);
        }
        
        public void OnHealthChange(Health playerHealth, float newValue)
        {
            var currentHealth = playerHealth.CurrentHealth;
            var maxHealth = playerHealth.MaxHealth;
            var healthPercentage = (currentHealth / maxHealth) * 100f;
            
            HandleColorChange(healthPercentage);
            UpdateLivesDisplay(currentHealth, maxHealth);
        }

        private void UpdateLivesDisplay(float currentHealth, float maxHealth)
        {
            var livesToDisplay = Mathf.CeilToInt(currentHealth * lives.Length / maxHealth);
            for (int i = livesToDisplay; i < lives.Length; i++)
            {
                lives[i].gameObject.SetActive(false);
            }
        }
        private void HandleColorChange(float healthPercentage)
        {
            if (healthPercentage >= HighHealthPercentage)
            {
                SetLifeColor(colors.highColor);
                return;
            }
            
            if (healthPercentage >= LowHealthPercentage)
            {
                SetLifeColor(colors.midColor);
                return;
            }
            
            SetLifeColor(colors.lowColor);
            return;
        }

        private void SetLifeColor(Color color)
        {
            foreach (var lifeImg in lives)
                lifeImg.color = color;
        }

        private void InitLivesDisplay()
        {
            foreach (var lifeImg in lives)
                lifeImg.gameObject.SetActive(true);
        }
    }
}