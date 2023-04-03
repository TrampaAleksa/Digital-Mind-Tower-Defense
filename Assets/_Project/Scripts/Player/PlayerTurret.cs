using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTurret : MonoBehaviour
{
    public Transform rotationObj;
    public float rotSpeed = 1f;

    public Transform gunTip;
    public GameObject projectile;
    
     public PlayerInput input;

    
    public void Shoot()
        => Instantiate(projectile, gunTip.position, gunTip.rotation);
    public void RotateTurret(Direction direction)
    {
        var rotationDirection = GetRotationDirection(direction);
        var rotationInput = input.actions["Rotate"].ReadValue<Vector2>();
        var rotSpeedFactor = rotationInput.y * rotSpeed;
        rotationObj.Rotate(Vector3.up, Time.deltaTime * rotSpeedFactor);
    }

    private int GetRotationDirection(Direction direction)
    {
        if (direction == Direction.Clockwise)
            return 1;
        else return -1;
    }
}

public enum Direction
{
    Clockwise,
    CounterClockwise
}