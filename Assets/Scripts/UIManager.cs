using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager _gm;
    public TextMeshProUGUI score;
    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI timeRemaining;
    public GameObject startButton;

    private void Awake()
    {
        _gm = GameManager.Instance;
    }

    private void Update()
    {
        score.text = $"Score: {_gm.ScoreManager.Score}";
        bestScore.text = $"Best score: {_gm.ScoreManager.BestScore}";
        timeRemaining.text = $"Temps: {Math.Ceiling(_gm.TimeManager.Remaining)}";
    }

    public void StartGame()
    {
        startButton.SetActive(false);
    }

    public void StopGame()
    {
        startButton.SetActive(true);
    }
}