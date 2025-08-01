using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private UIManager uiManager;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        if (uiManager != null)
            uiManager.HideGameOver(); // Se till att den är dold i början
    }

    public void WinGame()
    {
        Debug.Log("You Win!");

        // Starta om spelet efter 3 sekunder (ingen UI visas för vinst)
        Invoke("RestartGame", 3f);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");

        if (uiManager != null)
            uiManager.ShowGameOver();

        Invoke("RestartGame", 3f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}