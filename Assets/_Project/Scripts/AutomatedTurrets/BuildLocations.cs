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

        public BuildLocation buildLocationPrefab;
        public int locationsOnLine = 5;
        public float buildLineLength = 20f;
        
        private Camera _camera;
        private RaycastHit _hit;

        public float buildCooldown = 5f;
        private TimedAction _timedAction;
        private bool _isOnCooldown;

        public List<Transform> buildList;
        
        private void Start()
        {
            _camera = Camera.main;
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            
            GenerateBuildLocationsInLine(locationsOnLine, buildLineLength);
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

        private void GenerateBuildLocationsInLine(int number,float lineLength)
        {

            foreach (var buildLine in buildList)
            {
                for (int i = 0; i < number; i++)
                {
                    var percentageOnLine = i / (float) number; // range from 0-1 ; start to end
                    Vector3 nextBuildPosition = buildLine.position + buildLine.forward * (percentageOnLine * lineLength);

                    var location = Instantiate(buildLocationPrefab, nextBuildPosition, buildLocationPrefab.transform.rotation);
                    locations.Add(location);
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
            foreach (var buildLocation in locations)
                buildLocation.ShowLocation();
        }

        public void HideBuildLocations()
        {
            foreach (var buildLocation in locations)
                buildLocation.HideLocation();
        }

        private void FinishCooldown()
        {
            _isOnCooldown = false;
        }
    }
}
