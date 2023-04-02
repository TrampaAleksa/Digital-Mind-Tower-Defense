using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurretBuilder : MonoBehaviour
    {
        public AutoTurret turretPrefab;
        private BuildLocations _buildLocations;
        
        public float buildCooldown = 5f;
        private TimedAction _timedAction;
        private bool _isOnCooldown;

        private void Awake()
        {
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            _buildLocations = GetComponent<BuildLocations>();
            _camera = Camera.main;
        }

        public void TryStartBuildProcess()
        {
            if (_isOnCooldown) return;

            _buildLocations.ShowBuildLocations();
            _isOnCooldown = true;
        }

        public void TryHandlingBuildProcess()
        {
            if (ClickedOnBuildLocation())
            {
                _hit.collider.GetComponent<BuildLocation>().BuildTurret(turretPrefab);
                FinishBuildProcess();
            }
        }
        
        private void FinishBuildProcess()
        {
            _buildLocations.HideBuildLocations();
            _timedAction.StartTimedAction(() => _isOnCooldown = false , buildCooldown);
        }

        
        private Camera _camera;
        private RaycastHit _hit;
        private bool ClickedOnBuildLocation()
        {
            if (!Input.GetKeyDown(KeyCode.Mouse0))
                return false;
            
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            var clickedOnBuildLocation = Physics.Raycast(ray, out _hit, 100f, LayerMask.GetMask("BuildLocation"));

            return clickedOnBuildLocation;

        }
        
    }
}