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

        private TimedAction _timedAction;

        private void Start()
        {
            _player = Player.Find;
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
        }
        
        private void Update()
        {
            TryShooting();
        }

        private void TryShooting()
        {
            var lookingAtPlayer = Physics.Raycast(_gunTip.position, _gunTip.forward, LayerMask.GetMask("Player"));
            if (!lookingAtPlayer)
                return;

            var inRange = Vector3.Distance(_player.transform.position, _gunTip.transform.position) <= _range;
            if (!inRange)
                return;

            if (_timedAction.timerActive) // don't start another loop if one is already active
                return;

            StartShootingTimer();
        }

        private void StartShootingTimer()
        {
            _timedAction.StartTimedAction(Shoot, _rateOfFire);
        }

        private void Shoot()
        {
            var projectile = Instantiate(_projectile, _gunTip.position, _gunTip.rotation);
            projectile.GetComponent<EnemyProjectile>().damage = _damage;
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