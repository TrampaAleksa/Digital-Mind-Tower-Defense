using System;
using UnityEngine;

namespace com.digitalmind.towertest
{
    /// <summary>
    /// Finds colliders under the object. Ff any of the colliders get triggered will trigger an Action.
    /// Used to prevent us from having to put the same script on every individual object with a collider.
    /// The parent should provide the logic, the colliders should just notify the parent of a collision.
    /// </summary>

    public class ColliderAggregate : MonoBehaviour
    {
        private Action<Collider, Collider> _onTriggerEnterAction;

        private void Start()
        {
            ListenForCollisions();
            AddOnTriggerEnterAction((Collider origin, Collider other) => Debug.Log("Aggregate test: Collision with " + other.name));
        }

        private void ListenForCollisions()
        {
            foreach (var currentCollider in GetComponentsInChildren<Collider>())
            {
                currentCollider
                    .gameObject.AddComponent<ColliderAggregateNotifier>()
                    .InjectAggregator(this);
            }
        }

        public void ReceiveTriggerEnterEvent(Collider origin, Collider other)// if you need you can add onTriggerStat and onTriggerExit actions as well
        {
            _onTriggerEnterAction.Invoke(origin, other);
        }
        public void AddOnTriggerEnterAction(Action<Collider , Collider> toAdd) => _onTriggerEnterAction += toAdd;
        public void RemoveOnTriggerEnterAction(Action<Collider, Collider> toRemove) => _onTriggerEnterAction -= toRemove;
    }
}