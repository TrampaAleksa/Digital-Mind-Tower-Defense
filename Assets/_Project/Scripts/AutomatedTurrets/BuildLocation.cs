using UnityEngine;

namespace com.digitalmind.towertest
{
    public class BuildLocation : MonoBehaviour
    {
        public bool isFree = true;
        [HideInInspector]
        public AutoTurret turret;

        public void ShowLocation()
        {
            if (isFree)
                gameObject.SetActive(true);
        }

        public void HideLocation()
        {
            gameObject.SetActive(false);
        }

        public void BuildTurret(AutoTurret turretToBuild)
        {
            if (!isFree) return;
           
            turret =  Instantiate(turretToBuild, transform.position, turretToBuild.transform.rotation);
            isFree = false;
        }
    }
}