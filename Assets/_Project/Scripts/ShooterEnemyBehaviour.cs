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
        public Transform gunTip;

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
                .SetRange(shootingRange)
                .SetGunTip(gunTip);
        }
        
        

    }
}