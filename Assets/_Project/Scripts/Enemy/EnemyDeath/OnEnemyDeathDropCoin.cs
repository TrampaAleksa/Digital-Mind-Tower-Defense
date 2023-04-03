using UnityEngine;

namespace com.digitalmind.towertest
{
    public class OnEnemyDeathDropCoin : MonoBehaviour, IEnemyDeathEvent
    {
        public GameObject coinObj;

        public void OnTriggerDeath(Enemy enemy)
        {
            Debug.Log("Enemy dropped coin.");
            Instantiate(coinObj, enemy.transform.position, coinObj.transform.rotation);
        }
    }
}