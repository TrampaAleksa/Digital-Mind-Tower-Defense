using System;

namespace com.digitalmind.towertest
{
    public class RunnerEnemyBehaviour : EnemyBehaviour
    {
        public float maxHealth = 5f;
        public float speed = 12f;
        public float damage = 3f;

        public override void SetUpBehaviour(Enemy enemy)
        {
            enemy.SetMaxHealth(maxHealth);
            enemy.SetSpeed(speed);
            enemy.gameObject.AddComponent<DamagePlayerOnContact>()
                .SetDamage(damage);
            enemy.gameObject.AddComponent<DestroyOnPlayerContact>();
        }
    }
}