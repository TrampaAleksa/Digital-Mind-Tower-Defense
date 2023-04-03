using System;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class ShooterEnemyBehaviour : EnemyBehaviour
    {
        public Transform gunTip;
        public ShooterEnemySOModel shooterData;

        public override void SetUpBehaviour(Enemy enemy)
        {
            enemy.SetMaxHealth(shooterData.maxHealth);
            enemy.SetSpeed(shooterData.speed);
            enemy.SetStoppingDistance(shooterData.stoppingDistance);

            enemy.gameObject
                .AddComponent<ShootAtPlayer>()
                .SetProjectile(shooterData.projectile)
                .SetDamage(shooterData.damagePerShot)
                .SetRateOfFire(shooterData.rateOfFire)
                .SetRange(shooterData.shootingRange)
                .SetGunTip(gunTip);
        }
        
        

    }
}