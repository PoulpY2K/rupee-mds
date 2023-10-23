using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeManager : MonoBehaviour
{
    private GameManager _gm;

    public Transform container;
    public Transform spawner;
    public Rupee rupeePrefab;
    public float delay = 1f;

    private List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _gm = GameManager.Instance;
    }

    public void StartSpawning()
    {
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    public void StopSpawning()
    {
        if (_spawnCoroutine == null) return;

        StopCoroutine(_spawnCoroutine);
        _spawnCoroutine = null;
    }

    private IEnumerator SpawnCoroutine()
    {
        Spawn();
        yield return new WaitForSeconds(delay);
        StartSpawning();
    }

    private void Spawn()
    {
        var rupee = Instantiate(rupeePrefab, spawner.position, Quaternion.identity, container);
        rupee.OnCollected += RupeeCollectedHandler;
        _rupees.Add(rupee);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        rupee.OnCollected -= RupeeCollectedHandler;
        _rupees.Remove(rupee);
        _gm.ScoreManager.AddScore(rupee.score);
        Destroy(rupee.gameObject);
    }
}