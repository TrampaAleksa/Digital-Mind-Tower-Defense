using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class LeaderboardUI : MonoBehaviour
    {
        public LeaderboardResult singleResultPrefab;
        public GameObject resultsVerticalLayout;
        
        public List<LeaderboardResultModel> testResults;

        private List<LeaderboardResult> _resultContainers;

        public void Start()
        {
            foreach (var testResult in testResults)
            {
                var leaderboardResult = Instantiate(singleResultPrefab, resultsVerticalLayout.transform);
                leaderboardResult.SetResult(testResult);
            }
        }
    }


    [Serializable]
    public class LeaderboardResultModel
    {
        public int rank;
        public string name;
        public int score;
    }
}
