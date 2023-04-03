using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurretGun : MonoBehaviour
    {
        public GameObject projectile;
        public Transform gunTip;

        private AutoTurretRotation _turretRotation;
        
        public float reloadSpeed;

        private void Awake()
        {
            _turretRotation = GetComponent<AutoTurretRotation>();
            
            var autoShoot = gameObject.AddComponent<AutoShoot>();
            autoShoot.reloadSpeed = reloadSpeed;
            autoShoot.AddShootAction(OnShoot);
            autoShoot.SetShootingCondition(IsLookingAtEnemy);
            
            autoShoot.BeginShooting();
        }

        
        private bool IsLookingAtEnemy()
            => _turretRotation.IsLookingAtTarget;
        private void OnShoot()
            => Instantiate(projectile, gunTip.position, gunTip.rotation);
    }
}