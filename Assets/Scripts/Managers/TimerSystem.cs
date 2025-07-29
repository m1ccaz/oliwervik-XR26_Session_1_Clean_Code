using UnityEngine;
using System;

public class TimerSystem : MonoBehaviour
{
    public float totalTime = 60f;
    private float currentTime;
    public static event Action<float> OnTimerUpdated;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            OnTimerUpdated?.Invoke(currentTime);
        }
    }
}
