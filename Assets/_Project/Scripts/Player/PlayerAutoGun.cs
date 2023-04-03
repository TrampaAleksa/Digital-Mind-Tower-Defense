using System;
using com.digitalmind.towertest;
using UnityEngine;

public class PlayerAutoGun : MonoBehaviour
{
    public PlayerProjectileObjectPool projectilePool;
    public Transform gunTip;

    public float reloadSpeed;

    private void Awake()
    {
        var autoShoot = gameObject.AddComponent<AutoShoot>();
        autoShoot.reloadSpeed = reloadSpeed;
        autoShoot.AddShootAction(SpawnProjectile);

        autoShoot.BeginShooting();
    }

    private void SpawnProjectile()
    {
        var projectile = projectilePool.Get();

        projectile.transform.position = gunTip.position;
        projectile.transform.rotation = gunTip.rotation;
    }
}