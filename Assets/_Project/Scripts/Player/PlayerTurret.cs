using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public Transform rotationObj;
    public float rotSpeed = 1f;

    public Transform gunTip;
    public GameObject projectile;
    
    public void Shoot()
        => Instantiate(projectile, gunTip.position, gunTip.rotation);
    public void RotateTurret(int direction)
        => rotationObj.Rotate(Vector3.up, direction * Time.deltaTime * rotSpeed);
}