using System.Collections.Generic;

namespace com.digitalmind.towertest
{
    public class DummyLeaderboardData
    {
        public static List<LeaderboardResultModel> GetDummyModel()
        {
            List<LeaderboardResultModel> results = new List<LeaderboardResultModel>
            {
                new LeaderboardResultModel
                {
                    name = "Bob",
                    rank = 1,
                    score = 350
                },
                new LeaderboardResultModel
                {
                    name = "Mary",
                    rank = 2,
                    score = 300
                },
                new LeaderboardResultModel
                {
                    name = "Sue",
                    rank = 3,
                    score = 100
                },
                new LeaderboardResultModel
                {
                    name = "John",
                    rank = 4,
                    score = 50
                },
                new LeaderboardResultModel
                {
                    name = "Doe",
                    rank = 5,
                    score = 10
                },
            };

            return results;
        }
    }
}