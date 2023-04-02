using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurretGun : MonoBehaviour
    {
        public GameObject projectile;
        public Transform gunTip;
        
        private AutoTurret _turret;
        private TimedAction _timedAction;
        
        private bool _isShotReady;
        private bool _isReloading;


        private void Awake()
        {
            _turret = GetComponent<AutoTurret>();
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
        }

        private void Update()
        {
            TryReloading();
            TryShooting();
        }

        private void TryReloading()
        {
            if (!_isShotReady && !_isReloading)
                StartReload();
        }

        private void StartReload()
        {
            _isReloading = true;
            _timedAction.StartTimedAction(FinishReload, 0.5f);
        }

        private void FinishReload()
        {
            _isShotReady = true;
            _isReloading = false;
        }

        private void TryShooting()
        {
            if (!_isShotReady)
                return;
            
            if (_turret.IsLookingAtEnemy)
                Shoot();
        }

        private void Shoot()
        {
            _isShotReady = false;
            Instantiate(projectile, gunTip.position, gunTip.rotation);
        }
    }
}