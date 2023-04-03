using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurretProjectile : MonoBehaviour
    {
        public float speed = 120f;
        public float damage = 1f;
        void Update()
        {
            transform.Translate(transform.right * (speed * Time.deltaTime), Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                DamageEnemy(other.GetComponent<EnemyHitBox>().Enemy);
                Despawn();
                return;
            }

            if (other.CompareTag("Boundary"))
                Despawn();
        }

        private void DamageEnemy(Enemy enemy)
        {
            enemy.TakeDamage(damage);
        }

        private void Despawn()
        {
            Destroy(gameObject);
        }
    }
}
