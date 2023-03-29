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
        }
    }

    public class ShootAtPlayer : MonoBehaviour
    {
        public GameObject Projectile { get; set; }
        public float Damage { get; set; }
        public float RateOfFire { get; set; }
        public float Range { get; set; }

        private Player _player;
        private void Start()
        {
            _player = Player.Find;
        }

        public void TryShooting(Transform startingPosition)
        {
            
        }
        
        


    }
}