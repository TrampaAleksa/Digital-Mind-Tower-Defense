using UnityEngine;

namespace com.digitalmind.towertest
{
    public class AutoTurretRotation : MonoBehaviour
    {
        public Transform rotationObj;
        
        public float rotSpeed = 6f;
        public float lockOnAngle = 2.5f;

        private Transform _initialTarget;
        private Transform _target;

        private void Start()
        {
            _initialTarget = new GameObject("InitialTarget").transform;
            _initialTarget.position = rotationObj.position;
            _initialTarget.rotation = rotationObj.rotation;
        }

        public void RotateToTarget(Transform target)
        {
            _target = target;
            
            TurretRotation =
                Quaternion.Slerp(
                    TurretRotation,
                    RotationToTarget,
                    Time.deltaTime * rotSpeed);
        }

        public void RotateToInitialPosition()
        {
            _target = _initialTarget;
            
            TurretRotation =
                Quaternion.Slerp(TurretRotation, _initialTarget.rotation, Time.deltaTime * rotSpeed);
        }

        
        public Quaternion TurretRotation { get => rotationObj.rotation; private set => rotationObj.rotation = value; }
        public Vector3 DirectionToTarget => _target.position - rotationObj.position;
        public Quaternion RotationToTarget => Quaternion.LookRotation(DirectionToTarget);
        public bool IsLookingAtTarget => Vector3.Angle(rotationObj.forward, DirectionToTarget) < lockOnAngle;
        
    }
}