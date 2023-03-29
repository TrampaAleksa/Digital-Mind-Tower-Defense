using UnityEngine;

namespace com.digitalmind.towertest
{
    public class EnemyProjectile : MonoBehaviour
    {
        public float speed = 15f;
        public float damage;
        void Update()
        {
            transform.Translate(transform.right * (speed * Time.deltaTime), Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                DamagePlayer(other.GetComponent<PlayerHitBox>().Player);
                Despawn();
                return;
            }

            if (other.CompareTag("Boundary"))
                Despawn();
        }

        private void DamagePlayer(Player player)
        {
            player.TakeDamage(damage);
        }

        private void Despawn()
        {
            Destroy(gameObject);
        }
    }
}