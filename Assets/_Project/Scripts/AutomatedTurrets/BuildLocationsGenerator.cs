using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class BuildLocationsGenerator : MonoBehaviour
    {
        public List<Transform> buildLines;
        public BuildLocation buildLocationPrefab;
        
        public int locationsOnLine = 8;
        public float buildLineLength = 100f;
        
        public List<BuildLocation> GenerateBuildLocations()
        {
            var locations = new List<BuildLocation>();
            
            foreach (var buildLine in buildLines)
            {
                for (int i = 0; i < locationsOnLine; i++)
                {
                    var percentageOnLine = i / (float) locationsOnLine; // range from 0-1 ; start to end
                    var location = GenerateAtPercentage(buildLine, percentageOnLine);
                    
                    locations.Add(location);
                }
            }

            return locations;
        }
        
        private BuildLocation GenerateAtPercentage(Transform buildLine, float percentageOnLine)
        {
            Vector3 generatePosition =
                buildLine.position +
                buildLine.forward * (percentageOnLine * buildLineLength);

            var location = Instantiate(
                buildLocationPrefab,
                generatePosition,
                buildLocationPrefab.transform.rotation);

            return location;
        }
    }
}