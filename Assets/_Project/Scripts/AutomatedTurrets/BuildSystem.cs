using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class BuildSystem : MonoBehaviour
    {
        public List<BuildLocation> locations;

        private BuildLocationsGenerator _locationsGenerator;
        private BuildLocationsDisplay _locationsDisplay;
        private AutoTurretBuilder _autoTurretBuilder;
        private AutoTurretBuildClickDetection _buildLocationClickDetection;

        private void Awake()
        {
            _locationsGenerator = GetComponent<BuildLocationsGenerator>();
            _locationsDisplay = GetComponent<BuildLocationsDisplay>();
            _autoTurretBuilder = GetComponent<AutoTurretBuilder>();
            _buildLocationClickDetection = GetComponent<AutoTurretBuildClickDetection>();
        }
        private void Start()
        {
            locations = _locationsGenerator.GenerateBuildLocations();
            _locationsDisplay.HideBuildLocations();
        }

        public void OnBuildButtonClicked()
        {
            _autoTurretBuilder.TryStartBuildProcess();
        }

        private void Update()
        {
            if (!_buildLocationClickDetection.ClickedOnBuildLocation()) 
                return;
            
            var buildLocationHit = _buildLocationClickDetection.BuildLocationHit;
            _autoTurretBuilder.BuildOnLocation(buildLocationHit);
        }

        public void ShowBuildLocations()
        {
            _locationsDisplay.ShowBuildLocations();
        }
        public void HideBuildLocations()
        {
            _locationsDisplay.HideBuildLocations();
        }
    }
}
