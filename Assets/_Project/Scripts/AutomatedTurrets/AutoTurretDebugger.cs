using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurretDebugger : MonoBehaviour
    {
        private AutoTurret _turret;

        public bool debugAngle;
        public bool debugIsLooking;

        private void Awake()
        {
            _turret = GetComponent<AutoTurret>();
        }

        private void Update()
        {
            DebugTurret();
        }

        private void DebugTurret()
        {
            Debug.DrawRay(rotationObj.position, rotationObj.forward*50f, Color.red);

            if (!_turret.HasEnemiesInRange) 
                return;
            
            Debug.DrawRay(rotationObj.position, _turret.DirectionToLockedOnEnemy);
                
            if (debugAngle)
                Debug.Log(Vector3.Angle(rotationObj.forward,
                    _turret.DirectionToLockedOnEnemy));
                
            if (debugIsLooking)
                Debug.Log("Looking: " + _turret.IsLookingAtEnemy);
        }

        private Transform rotationObj => _turret.rotationObj;
    }
}