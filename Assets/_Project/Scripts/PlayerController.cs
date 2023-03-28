using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerTurret;
    public float rotSpeed  = 1f;

    public Transform gunTip;
    public GameObject projectile;

    void Update()
    {
       HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateTurret(1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            RotateTurret(-1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var projectileObj = Instantiate(projectile, gunTip.position, gunTip.rotation);
        }
    }

    private void RotateTurret(int direction)
    {
        playerTurret.Rotate(Vector3.up, direction * Time.deltaTime * rotSpeed);
    }
}
