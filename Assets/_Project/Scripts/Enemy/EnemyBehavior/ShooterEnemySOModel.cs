using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    //TODO - create SO models for some other classes - Runner enemy, player, auto turret, etc.
    [CreateAssetMenu(fileName = "ShooterEnemyData", menuName = "ScriptableObjects/ShooterEnemyData", order = 1)]
    public class ShooterEnemySOModel : ScriptableObject 
    {
        public float maxHealth = 2f;

        public float speed = 8f;
        public float stoppingDistance = 40f;

        public float rateOfFire = 3f;
        public float damagePerShot = 2f;
        public float shootingRange = 40f;
        
        public GameObject projectile;
    }
}