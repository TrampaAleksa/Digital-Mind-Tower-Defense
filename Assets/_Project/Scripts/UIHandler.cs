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
        public LifeColor[] colors;

        public void Start()
        {
            foreach (var lifeImg in lives)
            {
                lifeImg.color = colors[0].color;
            }
        }
    }
}
