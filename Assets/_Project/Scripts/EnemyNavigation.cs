using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace com.digitalmind.towertest
{
    public class EnemyNavigation : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void StartNavigation(Transform target)
        {
            _agent.SetDestination(target.position);
        }
    }
}