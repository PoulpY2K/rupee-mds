using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton pattern
    public static GameManager Instance { get; private set; }

    public ScoreManager ScoreManager { get; private set; }
    public RupeeManager RupeeManager { get; private set; }
    public TimeManager TimeManager { get; private set; }
    public UIManager UIManager { get; private set; }
    

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != null) Destroy(gameObject);

        ScoreManager = GetComponent<ScoreManager>();
        RupeeManager = GetComponent<RupeeManager>();
        TimeManager = GetComponent<TimeManager>();
        UIManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        TimeManager.OnTimeUp += TimeUpHandler;
    }

    private void TimeUpHandler()    
    {
        StopGame();
    }

    private void StopGame()
    {
        UIManager.StopGame();
        //RupeeManager.StopSpawning();
        TimeManager.StopGame();
    }

    public void StartGame()
    {
        ScoreManager.Reset();
        RupeeManager.StartSpawning();
        TimeManager.StartGame();
        UIManager.StartGame();
    }
}