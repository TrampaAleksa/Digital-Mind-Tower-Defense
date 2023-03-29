using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public Transform rotationObj;
    public float rotSpeed = 1f;

    public Transform gunTip;
    public GameObject projectile;
    
    public void Shoot()
        => Instantiate(projectile, gunTip.position, gunTip.rotation);
    public void RotateTurret(Direction direction)
    {
        var rotationDirection = GetRotationDirection(direction);
        rotationObj.Rotate(Vector3.up, rotationDirection * Time.deltaTime * rotSpeed);
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