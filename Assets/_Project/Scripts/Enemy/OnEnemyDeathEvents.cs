using UnityEngine;

namespace com.digitalmind.towertest
{
    public class OnEnemyDeathEvents : MonoBehaviour, IEnemyDeathEvent
    {
        public void OnTriggerDeath(Enemy enemy)
        {
            Debug.Log("Enemy died.");
            Destroy(enemy.gameObject);
        }
    }
}