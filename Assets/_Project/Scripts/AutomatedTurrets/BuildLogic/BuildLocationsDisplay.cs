using UnityEngine;
using UnityEngine.UI;

namespace com.digitalmind.towertest
{
    public class BuildLocationsDisplay : MonoBehaviour
    {
        private BuildSystem _buildSystem;
        
        public Image buildButtonImg;
        public Color colorWhenDisabled;
        public Color colorWhenEnabled;

        public float scaleWhileEnabled = 1.3f;
        public float scaleWhileDisabled = 1f;
        
        private void Awake()
        {
            _buildSystem = GetComponent<BuildSystem>();
            SetScale(scaleWhileEnabled);
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

        public void SetBuildButtonVisibility(bool isVisible)
        {
            if (isVisible)
            {
                buildButtonImg.color = colorWhenEnabled;
                SetScale(scaleWhileEnabled);
            }
            else
            {
                buildButtonImg.color = colorWhenDisabled;
                SetScale(scaleWhileDisabled);
            }
        }
        
        private void SetScale(float scale) => buildButtonImg.transform.localScale = scale * Vector3.one;

    }
}