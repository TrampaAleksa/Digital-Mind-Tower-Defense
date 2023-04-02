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
            Debug.DrawRay(RotationObj.position, RotationObj.forward*50f, Color.red);

            if (!_turret.HasEnemiesInRange) 
                return;
            
            Debug.DrawRay(RotationObj.position, _turret.DirectionToLockedOnEnemy);
                
            if (debugAngle)
                Debug.Log(Vector3.Angle(RotationObj.forward,
                    _turret.DirectionToLockedOnEnemy));
                
            if (debugIsLooking)
                Debug.Log("Looking: " + _turret.IsLookingAtEnemy);
        }

        private Transform RotationObj => _turret.rotationObj;
    }
}