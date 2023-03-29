using UnityEngine;

namespace com.digitalmind.towertest
{
    public class DamagePlayerOnContact : MonoBehaviour
    {
        private float _damage;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log($"Damaged the player: {_damage}");
            }
        }

        public void SetDamage(float damage)
        {
            _damage = damage;
        }
    }
}