using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class RaycastUtility
    {
        
        
        public static bool CheckIfClicked(out RaycastHit hit, Camera camera, string layerName)
        {
            if (Application.platform == RuntimePlatform.Android)
                return CheckRaycastAndroid(out hit, camera, layerName);
            else
                return CheckRaycastWindows(out hit, camera, layerName);
        }


        private static bool CheckRaycastWindows(out RaycastHit hit, Camera camera, string layerName)
        {
            hit = new RaycastHit();

            if (!Input.GetMouseButtonDown(0))
                return false;

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, 100f,
                LayerMask.GetMask(layerName));
        }

        private static bool CheckRaycastAndroid(out RaycastHit hit, Camera camera, string layerName)
        {
            hit = new RaycastHit();

            for (var i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase != TouchPhase.Began) continue;

                Ray ray = camera.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit,100f, LayerMask.GetMask(layerName)))
                    return true;
            }

            return false;
        }
    }
}