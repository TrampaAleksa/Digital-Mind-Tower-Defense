using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurretGun : MonoBehaviour
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

        public void TryShooting(AutoTurret turret)
        {
            if (!_isShotReady)
                return;
            
            if (turret.IsLookingAtEnemy)
                Shoot();
        }

        private void Shoot()
        {
            _isShotReady = false;
            Instantiate(projectile, gunTip.position, gunTip.rotation);
        }
    }
}