using UnityEngine;

namespace com.digitalmind.towertest
{
    public class BuildLocationsDisplay : MonoBehaviour
    {
        private BuildSystem _buildSystem;

        private void Awake()
        {
            _buildSystem = GetComponent<BuildSystem>();
        }

        public void ShowBuildLocations()
        {
            foreach (var buildLocation in _buildSystem.locations)
                buildLocation.ShowLocation();
        }

        public void HideBuildLocations()
        {
            foreach (var buildLocation in _buildSystem.locations)
                buildLocation.HideLocation();
        }
    }
}