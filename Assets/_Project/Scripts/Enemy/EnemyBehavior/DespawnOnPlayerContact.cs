using UnityEngine;

namespace com.digitalmind.towertest
{
    public class DespawnOnPlayerContact : MonoBehaviour
    {
        private Enemy _enemy;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _enemy.TriggerEnemyDeath();
            }
        }

        public DespawnOnPlayerContact SetEnemy(Enemy enemy)
        {
            _enemy = enemy;
            return this;
        }
    }
}