using System;
using UnityEngine;

namespace com.digitalmind.towertest
{
    /// <summary>
    /// Composite Pattern - Any <see cref="IEnemyDeathEvent"/> present on the enemy
    /// will get triggered once <see cref="Enemy.TriggerEnemyDeath"/> is called.
    /// This allows us to add as many death events we want.
    /// </summary>
    public class OnEnemyDeathEvents : MonoBehaviour
    {
        public void TriggerEnemyDeathEvents(Enemy enemy)
        {
            var deathEvents = gameObject.GetComponents<IEnemyDeathEvent>();

            foreach (var deathEvent in deathEvents)
                deathEvent.OnTriggerDeath(enemy);
        }
    }
}