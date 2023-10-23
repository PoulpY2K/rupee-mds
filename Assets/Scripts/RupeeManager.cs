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
    public List<RupeeData> rupeesData;
    public AudioSource rupeeAudioSource;

    private List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _gm = GameManager.Instance;
    }

    public void Reset()
    {
        // Stop spawning
        StopSpawning();

        // Remove all rupees from the last to the beginning of the list
        for (var i = _rupees.Count - 1; i >= 0; i--)
        {
            RemoveRupee(_rupees[i]);
        }

        // Clear list
        _rupees.Clear();
    }

    private void RemoveRupee(Rupee rupee)
    {
        _rupees.Remove(rupee);
        rupee.OnCollected -= RupeeCollectedHandler;
        Destroy(rupee.gameObject);
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
        var data = rupeesData[UnityEngine.Random.Range(0, rupeesData.Count)];
        var rupee = Instantiate(rupeePrefab, spawner.position, Quaternion.identity, container);
        rupee.OnCollected += RupeeCollectedHandler;
        rupee.Data = data;
        _rupees.Add(rupee);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        rupeeAudioSource.transform.position = rupee.transform.position;
        rupeeAudioSource.clip = rupee.Data.collectClip;
        rupeeAudioSource.Play();

        _gm.ScoreManager.AddScore(rupee.score);

        RemoveRupee(rupee);
    }
}