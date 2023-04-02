using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class BuildLocations : MonoBehaviour
    {
        public List<BuildLocation> locations;
        public AutoTurret turretPrefab;

        private BuildLocationsGenerator _locationsGenerator;
        private BuildLocationsDisplay _locationsDisplay;
        private AutoTurretBuilder _autoTurretBuilder;

        private Camera _camera;
        private RaycastHit _hit;

        public float buildCooldown = 5f;
        private TimedAction _timedAction;
        private bool _isOnCooldown;

        private void Awake()
        {
            _locationsGenerator = GetComponent<BuildLocationsGenerator>();
            _locationsDisplay = GetComponent<BuildLocationsDisplay>();
            _autoTurretBuilder = GetComponent<AutoTurretBuilder>();
        }

        private void Start()
        {
            _camera = Camera.main;
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            
            locations = _locationsGenerator.GenerateBuildLocations();
            HideBuildLocations();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                OnBuildButtonClicked();
            }
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                var clickedOnBuildLocation = Physics.Raycast(ray, out _hit, 100f, LayerMask.GetMask("BuildLocation"));

                if (clickedOnBuildLocation)
                {
                    _hit.collider.GetComponent<BuildLocation>().BuildTurret(turretPrefab);
                    HideBuildLocations();
                    _timedAction.StartTimedAction(FinishCooldown, buildCooldown);
                }
            }
        }

        public void OnBuildButtonClicked()
        {
            if (!_isOnCooldown)
            {
                ShowBuildLocations();
                _isOnCooldown = true;
            }
        }
        
        public void ShowBuildLocations()
        {
            _locationsDisplay.ShowBuildLocations();
        }
        public void HideBuildLocations()
        {
            _locationsDisplay.HideBuildLocations();
        }

        private void FinishCooldown()
        {
            _isOnCooldown = false;
        }
    }
}
