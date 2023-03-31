using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class PauseGameHandler : MonoBehaviour
    {
        public static PauseGameHandler Instance;

        private bool _isPaused;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void TogglePause()
        {
            _isPaused = !_isPaused;
            SetIsPaused(_isPaused);
        }

        public void SetIsPaused(bool isPaused)
        {
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}
