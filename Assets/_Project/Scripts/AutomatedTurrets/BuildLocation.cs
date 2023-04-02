using UnityEngine;

namespace com.digitalmind.towertest
{
    public class BuildLocation : MonoBehaviour
    {
        public bool isFree = true;
        [HideInInspector]
        public AutoTurret turret;
        public Transform turretParent;

        public void BuildTurret(AutoTurret turretToBuild)
        {
            turret =  Instantiate(turretToBuild, turretParent);
            isFree = false;
        }
    }
}