using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class PickupClickDetection : MonoBehaviour
    {
        private Camera _camera;
        private RaycastHit _hit;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (RaycastUtility.CheckIfClicked(out _hit, _camera, "Pickup"))
                PickupClicked(_hit.collider.gameObject);
        }

        private void PickupClicked(GameObject pickupObj)
        {
            pickupObj.GetComponent<IPickup>().TriggerPickup();
        }
    }
}