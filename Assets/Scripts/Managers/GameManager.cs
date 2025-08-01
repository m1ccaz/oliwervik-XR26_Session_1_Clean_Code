using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private UIManager uiManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        if (uiManager != null)
            uiManager.HideGameOver(); 
    }

    public void WinGame()
    {
        Debug.Log("You Win!");
        Invoke("RestartGame", 3f);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");

        if (uiManager != null)
            uiManager.ShowGameOver();

        Invoke("RestartGame", 3f);
    }

    public void DamagePlayer(int amount)
    {
        
        PlayerHealth health = FindObjectOfType<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(amount);
        }
        else
        {
            Debug.LogWarning("PlayerHealth not found!");
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}