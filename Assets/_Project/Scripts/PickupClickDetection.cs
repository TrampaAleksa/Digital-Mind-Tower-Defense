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
            if (HasTouchedCoinWindows())
                PickupClicked(_hit.collider.gameObject);
            if (HasTouchedCoinAndroid())
                PickupClicked(_hit.collider.gameObject);
        }


        private void PickupClicked(GameObject pickupObj)
        {
            pickupObj.GetComponent<IPickup>().TriggerPickup();
        }

        private bool HasTouchedCoinWindows()
        {
            if (!Input.GetMouseButtonDown(0)) 
                return false;
            
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out _hit, 100f, LayerMask.GetMask("Pickup")); //TODO - Extract util method for raycasting to mouse posiiton
        }

        
        
        
        private bool HasTouchedCoinAndroid()
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