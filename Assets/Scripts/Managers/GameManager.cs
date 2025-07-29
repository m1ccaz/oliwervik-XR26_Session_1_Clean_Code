using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;

    void OnEnable()
    {
        Player.OnPlayerDied += GameOver;
    }

    void OnDisable()
    {
        Player.OnPlayerDied -= GameOver;
    }

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void GameOver()
    {
        uiManager.ShowGameOver();
    }
}
