using System;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class RunnerEnemyBehaviour : MonoBehaviour
    {
        public float maxHealth = 5f;
        public float speed = 12f;
        public float damage = 3f;

        private void Start()
        {
            SetUpBehaviour(GetComponent<Enemy>());
        }

        public void SetUpBehaviour(Enemy enemy)
        {
            enemy.SetMaxHealth(maxHealth);
            enemy.SetSpeed(speed);
            enemy.gameObject.AddComponent<DamagePlayerOnContact>()
                .SetDamage(damage);
            enemy.gameObject.AddComponent<DestroyOnPlayerContact>();
        }
    }
}