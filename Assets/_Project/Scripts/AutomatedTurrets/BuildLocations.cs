using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class BuildLocations : MonoBehaviour
    {
        public List<BuildLocation> locations;

        private BuildLocationsGenerator _locationsGenerator;
        private BuildLocationsDisplay _locationsDisplay;
        private AutoTurretBuilder _autoTurretBuilder;

        private void Awake()
        {
            _locationsGenerator = GetComponent<BuildLocationsGenerator>();
            _locationsDisplay = GetComponent<BuildLocationsDisplay>();
            _autoTurretBuilder = GetComponent<AutoTurretBuilder>();
        }
        private void Start()
        {
            locations = _locationsGenerator.GenerateBuildLocations();
            _locationsDisplay.HideBuildLocations();
        }

        private void Update()
        {
            _autoTurretBuilder.TryHandlingBuildProcess();
        }

        public void OnBuildButtonClicked()
        {
            _autoTurretBuilder.TryStartBuildProcess();
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
