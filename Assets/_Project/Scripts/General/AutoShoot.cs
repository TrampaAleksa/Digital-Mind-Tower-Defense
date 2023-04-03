using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.BaseCommands;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoShoot : MonoBehaviour
    {
        public float reloadSpeed;
        
        private bool _isActivated;
        
        private TimedAction _timedAction;
        private Action OnShotFired;
        
        private bool _isShotReady;
        private bool _isReloading;


        
        private void Awake()
        {
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
        }
        private void Update()
        {
            if (!_isActivated) 
                return;
            
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
            TriggerShootAction();
        }

                
        public void BeginShooting() => _isActivated = true;
        public void StopShooting() => _isActivated = false;
        
        public void AddShootAction(Action shootEvent) => OnShotFired += shootEvent;
        public void RemoveShootAction(Action shootEvent) => OnShotFired -= shootEvent;
        public void TriggerShootAction() => OnShotFired?.Invoke();

    }

}
