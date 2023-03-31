using com.digitalmind.towertest;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    public GameObject gameUIPanel;

    public void DisplayEndGamePanel()
    {
        //TODO - Properly extract pause logic
        //TODO - Disable input and remove game ui once game is over / paused
        PauseGameHandler.Instance.SetIsPaused(true); //TODO - Ui shouldn't handle pause logic
        DisplayScore();
        gameObject.SetActive(true);
        gameUIPanel.SetActive(false);
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
        gameUIPanel.SetActive(true);
        PauseGameHandler.Instance.SetIsPaused(false); 
        SceneManager.LoadScene("GameScene");
    }
}