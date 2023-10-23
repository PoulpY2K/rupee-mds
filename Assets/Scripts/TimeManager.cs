using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int duration = 20;

    public float Remaining { get; private set; }

    private bool _running = false;

    public event Action OnTimeUp;

    public void Reset()
    {
        Remaining = duration;
    }

    public void StartGame()
    {
        Reset();
        _running = true;
    }

    public void StopGame()
    {
        _running = false;
    }

    private void Update()
    {
        if (!_running) return;

        Remaining -= Time.deltaTime;

        if (Remaining <= 0)
        {
            Remaining = 0;
            StopGame();
            OnTimeUp?.Invoke();
        }
    }
}