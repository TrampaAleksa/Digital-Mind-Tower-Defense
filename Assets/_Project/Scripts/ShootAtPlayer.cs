using System;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class ShootAtPlayer : MonoBehaviour
    {
        private GameObject _projectile;
        private Transform _gunTip;
        private float _damage;
        private float _rateOfFire;
        private float _range;

        private Player _player;
        private void Start()
        {
            _player = Player.Find;
        }

        public void TryShooting()
        {
            var lookingAtPlayer = Physics.Raycast(_gunTip.position, _gunTip.forward, LayerMask.GetMask("Player"));

            if (!lookingAtPlayer)
                return;

            Instantiate(_projectile, _gunTip.position, _gunTip.rotation);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
                TryShooting();
        }

        
        
        public ShootAtPlayer SetProjectile(GameObject projectile)
        {
            _projectile = projectile;
            return this;
        }
        public ShootAtPlayer SetDamage(float damage)
        {
            _damage = damage;
            return this;
        }
        public ShootAtPlayer SetRateOfFire(float rateOfFire)
        {
            _rateOfFire = rateOfFire;
            return this;
        }
        public ShootAtPlayer SetRange(float range)
        {
            _range = range;
            return this;
        }
        public ShootAtPlayer SetGunTip(Transform gunTip)
        {
            _gunTip = gunTip;
            return this;
        }

    }
}