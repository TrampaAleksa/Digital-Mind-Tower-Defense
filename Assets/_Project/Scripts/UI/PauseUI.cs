using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.digitalmind.towertest
{
    public class PauseUI : MonoBehaviour
    {
        public GameObject gameUIPanel;
        public GameObject inputUIPanel;
        public PauseGameHandler pauseGameHandler;
        
        public void DisplayPausePanel()
        {
            gameUIPanel.SetActive(false);
            inputUIPanel.SetActive(false);
            gameObject.SetActive(true);
            pauseGameHandler.SetIsPaused(true);
        }

        public void ContinueGame()
        {
            gameUIPanel.SetActive(true);
            inputUIPanel.SetActive(true);
            gameObject.SetActive(false);
            pauseGameHandler.SetIsPaused(false);
        }

        public void OpenMainMenu()
        {
            pauseGameHandler.SetIsPaused(false);
            SceneLoader.LoadMainMenu();;
        }
    }
}
