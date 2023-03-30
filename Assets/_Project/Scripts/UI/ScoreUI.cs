using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.digitalmind.towertest
{
    public class ScoreUI : MonoBehaviour
    {
        public TextMeshProUGUI displayText;

        public void OnScoreChange(float newScore)
        {
            displayText.text = newScore.ToString();
        }
    }
}
