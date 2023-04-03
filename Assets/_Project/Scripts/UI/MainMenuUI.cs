using System.Collections;
using System.Collections.Generic;
using com.digitalmind.towertest;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject leaderboardPanel;
    
    public void StartGame()
    {
        SceneLoader.LoadGameScene();
    }

    public void OpenLeaderboard()
    {
        leaderboardPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}