using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); //TODO - Wrap scene loading logic
    }

    public void OpenLeaderboard()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}