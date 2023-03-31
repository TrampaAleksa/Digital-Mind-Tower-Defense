using com.digitalmind.towertest;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;

    public void DisplayEndGamePanel()
    {
        gameObject.SetActive(true);
    }
    
    public void DisplayScore()
    {
        scoreDisplay.text = ScoreHandler.Instance.CurrentScore.ToString();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}