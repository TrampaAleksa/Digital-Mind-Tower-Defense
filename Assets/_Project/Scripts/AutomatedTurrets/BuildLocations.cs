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
        
        private Camera _camera;
        private RaycastHit _hit;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                var clickedOnBuildLocation = Physics.Raycast(ray, out _hit, 100f, LayerMask.GetMask("BuildLocation"));

                if (clickedOnBuildLocation)
                {
                    _hit.collider.GetComponent<BuildLocation>().BuildTurret(turretPrefab);
                }
            }
            
        }
    }
}
