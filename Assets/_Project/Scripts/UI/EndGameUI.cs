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
        DisplayScore();
        gameObject.SetActive(true);
    }
    
    public void DisplayScore()
    {
        scoreDisplay.text = ScoreHandler.Instance.CurrentScore.ToString(); //TODO - End game ui should know about score handler
    }

    public void BackToMainMenu()
    {
        PauseGameHandler.Instance.SetIsPaused(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        PauseGameHandler.Instance.SetIsPaused(false); 
        SceneManager.LoadScene("GameScene");
    }
}