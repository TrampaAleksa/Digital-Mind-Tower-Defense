using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class PlayerInput : MonoBehaviour
    {
        public Player player;

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKey(KeyCode.A))
                player.RotateTurret(Direction.Clockwise);

            if (Input.GetKey(KeyCode.D))
                player.RotateTurret(Direction.CounterClockwise);

            if (Input.GetKeyDown(KeyCode.Space))
                player.Shoot();
        }
    }
}
