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
            _buildSystem.SetBuildButtonVisibility(false);

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
            _buildSystem.SetBuildButtonVisibility(true);
        }
    }
}