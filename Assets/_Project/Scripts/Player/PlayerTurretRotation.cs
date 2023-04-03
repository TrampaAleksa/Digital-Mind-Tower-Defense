using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTurretRotation : MonoBehaviour
{
    public Transform rotationObj;
    public float rotSpeed = 1f;

    public void RotateTurret(float rotationInput)
    {
        var rotSpeedFactor = rotationInput * rotSpeed;
        rotationObj.Rotate(Vector3.up, Time.deltaTime * rotSpeedFactor);
    }

}