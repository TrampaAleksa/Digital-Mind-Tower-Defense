using System;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurretBuildClickDetection : MonoBehaviour
    {
        private Camera _camera;
        private RaycastHit _hit;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public bool ClickedOnBuildLocation()
        {
            if (Application.platform == RuntimePlatform.Android)
                return HasTouchedBuildLocationAndroid();
            
            if (!Input.GetKeyDown(KeyCode.Mouse0))
                return false;

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            var clickedOnBuildLocation = Physics.Raycast(ray, out _hit, 100f, LayerMask.GetMask("BuildLocation"));

            return clickedOnBuildLocation;
        }

        public BuildLocation BuildLocationHit => _hit.collider
            .GetComponent<BuildLocation>();

        
        private bool HasTouchedBuildLocationAndroid()
        {
            for (var i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase != TouchPhase.Began) continue;

                Ray ray = _camera.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, 100f, LayerMask.GetMask("Pickup")))
                    return true;
            }

            return false;
        }
    }
}