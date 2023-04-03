using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.digitalmind.towertest
{
    public class AutoTurretBuilder : MonoBehaviour
    {
        public AutoTurret turretPrefab;
        private BuildSystem _buildSystem;

        public float buildCooldown = 5f;
        private TimedAction _timedAction;
        private bool _isOnCooldown;

        public Image buildButtonImg;
        public Color colorWhenDisabled;
        public Color colorWhenEnabled;
        
        private void Awake()
        {
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            _buildSystem = GetComponent<BuildSystem>();
        }

        public void TryStartBuildProcess()
        {
            if (_isOnCooldown) return;

            _buildSystem.ShowBuildLocations();
            _isOnCooldown = true;
            SetBuildButtonVisibility(false);

        }

        public void BuildOnLocation(BuildLocation buildLocation)
        {
            buildLocation.BuildTurret(turretPrefab);
            FinishBuildProcess();
        }
        
        private void FinishBuildProcess()
        {
            _buildSystem.HideBuildLocations();
            _timedAction.StartTimedAction(OnCooldownExpired , buildCooldown);
        }

        private void OnCooldownExpired()
        {
            _isOnCooldown = false;
            SetBuildButtonVisibility(true);
        }

        private void SetBuildButtonVisibility(bool isVisible)
        {
            if (isVisible)
                buildButtonImg.color = colorWhenEnabled;
            else 
                buildButtonImg.color = colorWhenDisabled;
        }
    }
}