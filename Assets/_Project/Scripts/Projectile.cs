using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
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
                Depawn();
                return;
            }

            if (other.CompareTag("Boundary"))
                Depawn();
        }

        private void DamageEnemy(Enemy enemy)
        {
            enemy.TakeDamage(damage);
        }

        private void Depawn()
        {
            Destroy(gameObject);
        }
    }
}
