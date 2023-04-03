using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    /// <summary>
    /// Shoots every <see cref="reloadSpeed"/> seconds.
    /// If reload finishes but <see cref="_shootingCondition"/> isn't met, will delay the shot until it is.
    /// <see cref="OnShotFired"/> will get triggered once the shot is made.
    /// After a shot was made, the reload process starts again.
    /// </summary>
    public class AutoShoot : MonoBehaviour
    {
        public float reloadSpeed;
        private TimedAction _timedAction;
        
        private Action OnShotFired;
        private Func<bool> _shootingCondition = () => true;
        
        private bool _isShotReady;
        private bool _isReloading;
        private bool _isActivated;

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
            if (ShootingConditionMet)
                Shoot();
        }

        private void Shoot()
        {
            _isShotReady = false;

            if (ShootingConditionMet)
                TriggerShootAction();
        }

                
        public void BeginShooting() => _isActivated = true;
        public void StopShooting() => _isActivated = false;
        
        public void AddShootAction(Action shootEvent) => OnShotFired += shootEvent;
        public void RemoveShootAction(Action shootEvent) => OnShotFired -= shootEvent;
        public void TriggerShootAction() => OnShotFired?.Invoke();
        
        public void SetShootingCondition(Func<bool> condition) => _shootingCondition = condition;
        private bool ShootingConditionMet => _shootingCondition.Invoke();
    }

}
