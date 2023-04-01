using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class InputUI : MonoBehaviour
    {

        public GameObject androidInputsPanel;
        void Start()
        {
            androidInputsPanel.SetActive(Application.platform == RuntimePlatform.Android);
        }


    }
}
