using UnityEngine;

namespace com.digitalmind.towertest
{
    public class EnemyBehaviour : MonoBehaviour
    {
        public virtual void SetUpBehaviour(Enemy enemy)
        {
            Debug.Log("Def enemy Behaviour");
        }
    }
}