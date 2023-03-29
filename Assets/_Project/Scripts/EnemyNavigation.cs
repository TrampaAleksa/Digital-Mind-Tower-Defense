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
        public PlayerController player;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                _agent.SetDestination(player.transform.position);
            }
        }
    }
}
