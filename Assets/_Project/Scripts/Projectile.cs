using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        void Update()
        {
            transform.Translate(transform.right * (speed * Time.deltaTime));
        }
    }
}
