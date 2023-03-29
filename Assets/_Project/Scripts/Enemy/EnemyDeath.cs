using UnityEngine;

namespace com.digitalmind.towertest
{
    public class EnemyDeath : MonoBehaviour
    {
        public void TriggerEnemyDeath(Enemy enemy)
        {
            Debug.Log("Enemy died.");
            Destroy(enemy.gameObject);
        }
    }
}