using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Slider healthSlider;

    void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateHealthUI;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateHealthUI;
    }

    void Start()
    {
        UpdateHealthUI(100);
    }

    void UpdateHealthUI(int newHealth)
    {
        if (healthSlider != null)
            healthSlider.value = newHealth;
    }
}