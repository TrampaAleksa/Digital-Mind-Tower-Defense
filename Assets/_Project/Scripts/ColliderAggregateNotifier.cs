using UnityEngine;

namespace com.digitalmind.towertest
{
    /// <summary>
    /// Listeners added by the <see cref="ColliderAggregate"/>.
    /// They pass a collision event to the aggregate.
    /// </summary>
    public class ColliderAggregateNotifier : MonoBehaviour
    {
        private ColliderAggregate _aggregate;

        private void OnTriggerEnter(Collider origin, Collider other)
        {
            _aggregate.ReceiveTriggerEnterEvent(origin, other); // Notify the aggregate that a collider was triggered
        }

        public void InjectAggregator(ColliderAggregate aggregate) => _aggregate = aggregate;
    }
}