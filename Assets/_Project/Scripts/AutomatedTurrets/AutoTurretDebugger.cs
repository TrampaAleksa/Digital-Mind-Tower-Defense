using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurretDebugger : MonoBehaviour
    {
        private AutoTurretRotation _turretRotation;
        private AutoTurretLockOn _turretLockOn;

        public bool debugAngle;
        public bool debugIsLooking;

        private void Awake()
        {
            _turretRotation = GetComponent<AutoTurretRotation>();
            _turretLockOn = GetComponent<AutoTurretLockOn>();
        }

        private void Update()
        {
            DebugTurret();
        }

        private void DebugTurret()
        {
            Debug.DrawRay(RotationObj.position, RotationObj.forward*50f, Color.red);

            if (!_turretLockOn.HasEnemiesInRange) 
                return;
            
            Debug.DrawRay(RotationObj.position, _turretRotation.DirectionToTarget);
                
            if (debugAngle)
                Debug.Log(Vector3.Angle(RotationObj.forward,
                    _turretRotation.DirectionToTarget));
                
            if (debugIsLooking)
                Debug.Log("Looking: " + _turretRotation.IsLookingAtTarget);
        }

        private Transform RotationObj => _turretRotation.rotationObj;
    }
}