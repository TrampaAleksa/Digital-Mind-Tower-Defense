using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.digitalmind.towertest
{
    public class UIHandler : MonoBehaviour
    {
        public Image[] lives;
        public LifeColor[] colors; // TODO - Use single struct with the three colors predefined inside

        public void Start()
        {
            SetLifeColor(colors[0].color);
        }
        
        public void OnHealthChange(Health playerHealth, float newValue)
        {
            var healthPercentage = (newValue / playerHealth.MaxHealth) * 100f;
            
            if (healthPercentage >= 66)
            {
                SetLifeColor(colors[0].color);
                return;
            }
            if (healthPercentage >= 33)
            {
                SetLifeColor(colors[1].color);
                return;
            }
            SetLifeColor(colors[2].color);
            return;
        }


        private void SetLifeColor(Color color)
        {
            foreach (var lifeImg in lives)
                lifeImg.color = color;
        }
    }
}