using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.digitalmind.towertest
{
    //TODO - Every on click event of buttons should be triggering events from UI Handler that then call methods from UI scripts.
    public class PauseUI : MonoBehaviour
    {
        public GameObject gameUIPanel;
        public PauseGameHandler pauseGameHandler;
        
        public void DisplayPausePanel()
        {
            gameUIPanel.SetActive(false);
            gameObject.SetActive(true);
            pauseGameHandler.SetIsPaused(true);
        }

        public void ContinueGame()
        {
            gameUIPanel.SetActive(true);
            gameObject.SetActive(false);
            pauseGameHandler.SetIsPaused(false);
        }

        public void OpenMainMenu()
        {
            pauseGameHandler.SetIsPaused(true);
            SceneManager.LoadScene("MainMenu");
        }
    }
}