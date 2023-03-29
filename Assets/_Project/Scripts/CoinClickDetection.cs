using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class CoinClickDetection : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (HasTouchedCoinWindows())
                CoinClicked();
        }


        private void CoinClicked()
        {
            Debug.Log("Clicked on coin");
        }

        private bool HasTouchedCoinWindows()
        {
            if (!Input.GetMouseButtonDown(0)) 
                return false;
            
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, 100f, LayerMask.GetMask("Pickup"));
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