using System;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class ShooterEnemyBehaviour : EnemyBehaviour
    {
        //TODO - Extract into a Scriptable Object(s)
        public float maxHealth = 2f;
        
        public float speed = 8f;
        public float stoppingDistance = 40f;
        
        public float rateOfFire = 3f;
        public float damagePerShot = 2f;
        public float shootingRange;
        public GameObject projectile;

        public override void SetUpBehaviour(Enemy enemy)
        {
            enemy.SetMaxHealth(maxHealth);
            enemy.SetSpeed(speed);
            enemy.SetStoppingDistance(stoppingDistance);

            enemy.gameObject
                .AddComponent<ShootAtPlayer>()
                .SetProjectile(projectile)
                .SetDamage(damagePerShot)
                .SetRateOfFire(rateOfFire)
                .SetRange(shootingRange);
        }
    }

    public class ShootAtPlayer : MonoBehaviour
    {
        private GameObject _projectile;
        private float _damage;
        private float _rateOfFire;
        private float _range;

        private Player _player;
        private void Start()
        {
            _player = Player.Find;
        }

        public void TryShooting(Transform startingPosition)
        {
            
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
    }
}