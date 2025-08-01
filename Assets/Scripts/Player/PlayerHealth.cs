using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static event Action<int> OnHealthChanged;

    private int health = 100;

    void Start()
    {
        
        OnHealthChanged?.Invoke(health);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, 100);

        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
          
          Debug.Log("HP = 0, men vi väntar på fiender.");
           
        }
    }

    public void ResetHealth()
    {
        health = 100;
        OnHealthChanged?.Invoke(health);
    }
}