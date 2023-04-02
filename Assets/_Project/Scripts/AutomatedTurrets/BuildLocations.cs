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

        private void Start()
        {
            _camera = Camera.main;

            GenerateBuildLocationsInLine(locationsOnLine, buildLineLength);
        }

        private void GenerateBuildLocationsInLine(int number,float lineLength)
        {
            for (int i = 0; i < number; i++)
            {
                var percentageOnLine = i / (float) number; // range from 0-1 ; start to end
                Vector3 nextBuildPosition = transform.position + transform.forward * (percentageOnLine * lineLength);

                var location = Instantiate(buildLocationPrefab, nextBuildPosition, buildLocationPrefab.transform.rotation);
                locations.Add(location);
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                GenerateBuildLocationsInLine(locationsOnLine, buildLineLength);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                var clickedOnBuildLocation = Physics.Raycast(ray, out _hit, 100f, LayerMask.GetMask("BuildLocation"));

                if (clickedOnBuildLocation)
                {
                    _hit.collider.GetComponent<BuildLocation>().BuildTurret(turretPrefab);
                    HideBuildLocations();
                }
            }
        }
    }
}
