using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace com.digitalmind.towertest
{
    public class TurretInput : MonoBehaviour
    {
        public Player player;
        public PlayerInput input; 
        
        private void Update()
        {
            HandleInputSystem();
        }


        private void HandleInputSystem()
        {
            var rotationInput = input.actions["Rotate"].ReadValue<Vector2>();
            
            var inputSensitivity = 0.1f;
            if (rotationInput.y > inputSensitivity)
                player.RotateTurret(Direction.Clockwise);

            if (rotationInput.y < -inputSensitivity)
                player.RotateTurret(Direction.CounterClockwise);

            if (input.actions["Fire"].WasPressedThisFrame())
                player.Shoot();
        }
    }
}
