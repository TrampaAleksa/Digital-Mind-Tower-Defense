using UnityEngine;

namespace com.digitalmind.towertest
{
    public class BuildLocationsDisplay : MonoBehaviour
    {
        private BuildLocations _buildLocations;

        private void Awake()
        {
            _buildLocations = GetComponent<BuildLocations>();
        }

        public void ShowBuildLocations()
        {
            foreach (var buildLocation in _buildLocations.locations)
                buildLocation.ShowLocation();
        }

        public void HideBuildLocations()
        {
            foreach (var buildLocation in _buildLocations.locations)
                buildLocation.HideLocation();
        }
    }
}