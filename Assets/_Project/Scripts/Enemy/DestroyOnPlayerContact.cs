using UnityEngine;

namespace com.digitalmind.towertest
{
    public class DestroyOnPlayerContact : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}