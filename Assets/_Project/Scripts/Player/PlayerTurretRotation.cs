using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTurretRotation : MonoBehaviour
{
    public Transform rotationObj;
    public float rotSpeed = 1f;

    public PlayerInput input; //TODO - Rotation shouldn't know about input

    public void RotateTurret()
    {
        var rotationInput = input.actions["Rotate"].ReadValue<Vector2>();
        var rotSpeedFactor = rotationInput.y * rotSpeed;
        rotationObj.Rotate(Vector3.up, Time.deltaTime * rotSpeedFactor);
    }

}