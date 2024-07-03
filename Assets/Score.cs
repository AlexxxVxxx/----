using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private string firstUserName;
    private string secondUserName;
    public int firstUserScore = 0;
    public int secondUserScore = 0;
    public TextMeshProUGUI scoreBoard;

    public void Start()
    {
        LoadUsers();
        LoadScores();
        UpdateScoreBoard();
    }

    public void IncrementFirstUserScore()
    {
        firstUserScore++;
        SaveScores();
        UpdateScoreBoard();
    }

    public void IncrementSecondUserScore()
    {
        secondUserScore++;
        SaveScores();
        UpdateScoreBoard();
    }

    private void UpdateScoreBoard()
    {
        scoreBoard.text = $"{firstUserScore} - {secondUserScore}";
    }

    private void LoadUsers()
    {
        firstUserName = PlayerPrefs.GetString("FirstPlayerName", "Player 1");
        secondUserName = PlayerPrefs.GetString("SecondPlayerName", "Player 2");
    }

    private void LoadScores()
    {
        firstUserScore = PlayerPrefs.GetInt($"{firstUserName}_Score", 0);
        secondUserScore = PlayerPrefs.GetInt($"{secondUserName}_Score", 0);
    }

    private void SaveScores()
    {
        PlayerPrefs.SetInt($"{firstUserName}_Score", firstUserScore);
        PlayerPrefs.SetInt($"{secondUserName}_Score", secondUserScore);
        PlayerPrefs.Save();
    }
}
