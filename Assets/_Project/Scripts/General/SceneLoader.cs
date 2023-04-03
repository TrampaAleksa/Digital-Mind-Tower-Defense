using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.digitalmind.towertest
{
    public class SceneLoader : MonoBehaviour
    {

        public static void LoadGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }

        public static void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
