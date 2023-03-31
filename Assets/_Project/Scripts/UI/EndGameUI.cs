using com.digitalmind.towertest;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;

    public void DisplayEndGamePanel()
    {
        PauseGameHandler.Instance.SetIsPaused(true); //TODO - Ui shouldn't handle pause logic
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