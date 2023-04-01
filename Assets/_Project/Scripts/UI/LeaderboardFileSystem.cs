using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class LeaderboardFileSystem
    {
        private const string FileName = "leaderboard.txt";

        public List<LeaderboardResultModel> ReadResultsFromFile()
        {
            var resultsJson = ReadFromFIle(FileName);

            var results = JsonConvert.DeserializeObject<List<LeaderboardResultModel>>(resultsJson);
            return results;
        }

        public void TryAddingResultToFile(string name, float score)
        {
        }

        public void WriteInitialLeaderboard()
        {
            if (ReadFromFIle(FileName) == "File not found")
            {
                List<LeaderboardResultModel> results = DummyLeaderboardData.GetDummyModel();

                var jsonResults = JsonConvert.SerializeObject(results);
                WriteToFile(FileName, jsonResults);
            }
        }


        private void WriteToFile(string fileName, string json)
        {
            string path = GetFilePath(fileName);
            FileStream fileStream = new FileStream(path, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        private string ReadFromFIle(string fileName)
        {
            string path = GetFilePath(fileName);
            if (!File.Exists(path))
                return "File not found";
            
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }

        private string GetFilePath(string fileName)
        {
            return Application.persistentDataPath + "/" + fileName;
        }
    }
}