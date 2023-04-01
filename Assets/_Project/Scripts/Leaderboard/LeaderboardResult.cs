using TMPro;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class LeaderboardResult : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI rankDisplay;
        [SerializeField]
        private TextMeshProUGUI nameDisplay;
        [SerializeField]
        private TextMeshProUGUI scoreDisplay;

        public void SetResult(LeaderboardResultModel resultModel)
        {
            rankDisplay.text = resultModel.rank.ToString();
            nameDisplay.text = resultModel.name;
            scoreDisplay.text = resultModel.score.ToString();
        }
    }
}