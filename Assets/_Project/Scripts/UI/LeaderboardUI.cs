using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class LeaderboardUI : MonoBehaviour
    {
        public LeaderboardResult singleResultPrefab;
        public GameObject resultsVerticalLayout;
        
        private readonly List<LeaderboardResult> _resultContainers = new List<LeaderboardResult>();


        public void Start()
        {
            LoadLeaderboard();
        }

        private  void LoadLeaderboard()
        {
            ClearCurrentLeaderboardResults();
            var resultsToInflate = ReadLeaderboardResults();
            InflateLeaderboardResults(resultsToInflate);
        }

        private List<LeaderboardResultModel> ReadLeaderboardResults()
        {
            var fileSystem = new LeaderboardFileSystem();
            fileSystem.WriteInitialLeaderboard();
            
            var resultsFromJson = fileSystem.ReadResultsFromFile();
            return resultsFromJson;
        }
        
        private void ClearCurrentLeaderboardResults()
        {
            foreach (var container in _resultContainers)
            {
                Destroy(container.gameObject);
            }
            _resultContainers.Clear();
        }
        private void InflateLeaderboardResults(List<LeaderboardResultModel> resultModels)
        {
            foreach (var result in resultModels)
            {
                var leaderboardResult = Instantiate(singleResultPrefab, resultsVerticalLayout.transform);
                _resultContainers.Add(leaderboardResult);
                leaderboardResult.SetResult(result);
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
