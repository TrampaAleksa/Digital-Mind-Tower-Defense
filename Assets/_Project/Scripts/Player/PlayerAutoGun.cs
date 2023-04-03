using System;
using com.digitalmind.towertest;
using UnityEngine;

public class PlayerAutoGun : MonoBehaviour // TODO - extract component for auto shooting that the player and auto turrets will use
{
    public GameObject projectile;
    public Transform gunTip;

    private TimedAction _timedAction;

    private bool _isShotReady;
    private bool _isReloading;

    public float reloadSpeed;

    private void Awake()
    {
        _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
    }

    private void Update()
    {
        TryReloading();
        TryShooting();
    }

    public void TryReloading()
    {
        if (!_isShotReady && !_isReloading)
            StartReload();
    }

    public void StartReload()
    {
        _isReloading = true;
        _timedAction.StartTimedAction(FinishReload, reloadSpeed);
    }

    private void FinishReload()
    {
        _isShotReady = true;
        _isReloading = false;
    }

    public void TryShooting()
    {
        if (!_isShotReady)
            return;

        Shoot();
    }

    private void Shoot()
    {
        _isShotReady = false;
        Instantiate(projectile, gunTip.position, gunTip.rotation);
    }
}