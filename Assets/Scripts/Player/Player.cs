using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public float health = 100f;

    public static event Action OnPlayerDied;

    void Update()
    {
        // Tillfällig knapp för att ta skada (för test)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(25f);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died.");
        OnPlayerDied?.Invoke();
    }
}
