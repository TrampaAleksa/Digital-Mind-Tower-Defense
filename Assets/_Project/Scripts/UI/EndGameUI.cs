using com.digitalmind.towertest;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//TODO - Refactor everything - leaderboard input logic, pause logic; disable input on pause, ui shouldn't handle pause logic
public class EndGameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    public GameObject gameUIPanel;

    public TMP_InputField nameInput;

    public GameObject leaderboardInputContainer;
    public GameObject noHighScoreContainer;

    private bool _isHighScore = false;
    
    public void DisplayEndGamePanel()
    {
        PauseGameHandler.Instance.SetIsPaused(true);
        gameObject.SetActive(true);
        gameUIPanel.SetActive(false);

        _isHighScore = IsHighScore(ScoreHandler.Instance.CurrentScore);
        
        if (_isHighScore)
            DisplayLeaderboardInputContainer();
        else DisplayNoHighScoreContainer();
        
    }
    
    public void DisplayScore(TextMeshProUGUI scoreDisplay)
    {
        scoreDisplay.text = ScoreHandler.Instance.CurrentScore.ToString(); //TODO - End game ui shouldnt know about score handler
    }

    public void BackToMainMenu()
    {
        if (_isHighScore) // TODO - Move logic into leaderboard input class
            new LeaderboardFileSystem()
                .TryAddingResult(nameInput.text, ScoreHandler.Instance.CurrentScore);
        PauseGameHandler.Instance.SetIsPaused(false);
        SceneLoader.LoadMainMenu();
    }

    public void RestartGame()
    {
        if (_isHighScore)
            new LeaderboardFileSystem()
                .TryAddingResult(nameInput.text, ScoreHandler.Instance.CurrentScore);
        gameUIPanel.SetActive(true);
        PauseGameHandler.Instance.SetIsPaused(false); 
        SceneLoader.LoadGameScene();
    }

    private bool IsHighScore(int score) {
        var results = new LeaderboardFileSystem()
            .ReadResults();

        foreach(var result in results)
            if(result.score < score) return true;

        return false;
    }

    private void DisplayLeaderboardInputContainer() {
        leaderboardInputContainer.SetActive(true);
        noHighScoreContainer.SetActive(false);
        var scoreText = leaderboardInputContainer.transform.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();
        DisplayScore(scoreText);
    }

    private void DisplayNoHighScoreContainer() {
        leaderboardInputContainer.SetActive(false);
        noHighScoreContainer.SetActive(true);
        var scoreText = noHighScoreContainer.transform.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();
        DisplayScore(scoreText);

    }
}