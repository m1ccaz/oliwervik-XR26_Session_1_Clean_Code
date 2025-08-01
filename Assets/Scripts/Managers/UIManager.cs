using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;     // Dra in från Canvas
    public TMP_Text scoreText;           // Dra in TextMeshPro för poäng
    public TMP_Text timerText;

    void Start()
    {
        HideGameOver();
    }

    void OnEnable()
    {
        Player.OnScoreChanged += UpdateScore;
        TimerSystem.OnTimerUpdated += UpdateTimer;
    }

    void OnDisable()
    {
        Player.OnScoreChanged -= UpdateScore;
        TimerSystem.OnTimerUpdated -= UpdateTimer;
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

    }

    public void UpdateTimer(float time)
    {
        if (timerText != null)
            timerText.text = "Time: " + time.ToString("F1");
    }
}