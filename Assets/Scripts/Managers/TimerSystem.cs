using UnityEngine;
using System;

public class TimerSystem : MonoBehaviour
{
    public float totalTime = 60f;
    private float currentTime;

    public static event Action<float> OnTimerUpdated;
    public static event Action OnTimeUp;

    private bool isRunning = true;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime > 0)
        {
            OnTimerUpdated?.Invoke(currentTime);
        }
        else
        {
            isRunning = false;
            OnTimerUpdated?.Invoke(0f);
            OnTimeUp?.Invoke();
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}


