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
            return RaycastUtility.CheckIfClicked(out _hit, _camera, "BuildLocation");
        }

        public BuildLocation BuildLocationHit => _hit.collider
            .GetComponent<BuildLocation>();
    }
}