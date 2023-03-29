using UnityEngine;

namespace com.digitalmind.towertest
{
    /// <summary>
    /// The HitBox gives every collider a reference to one central script that handles the collisions.
    /// This is so that the hit box and the script don't have to be on the same object.
    /// </summary>
    public class EnemyHitBox : MonoBehaviour
    {
        private  Enemy _enemy;
        public Enemy Enemy => _enemy;

        
        private void InjectEnemy(Enemy enemy) => _enemy = enemy;

        public static void AddHitBoxesToColliders(Enemy parentObject)
        {
            foreach (var currentCollider in parentObject.GetComponentsInChildren<Collider>())
            {
                currentCollider
                    .gameObject.AddComponent<EnemyHitBox>()
                    .InjectEnemy(parentObject);
            }
        }
    }
}