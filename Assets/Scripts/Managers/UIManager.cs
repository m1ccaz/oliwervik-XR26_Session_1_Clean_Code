using UnityEngine;
using TMPro; // ← för TextMeshPro

public class UIManager : MonoBehaviour
{
    public TMP_Text timerText; // ← ändrat till TMP_Text
    public GameObject gameOverPanel;

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void UpdateTimerUI(float time)
    {
        if (timerText != null)
            timerText.text = "Time: " + time.ToString("F1");
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    void OnEnable()
    {
        TimerSystem.OnTimerUpdated += UpdateTimerUI;
    }

    void OnDisable()
    {
        TimerSystem.OnTimerUpdated -= UpdateTimerUI;
    }
}