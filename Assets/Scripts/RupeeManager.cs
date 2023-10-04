using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeManager : MonoBehaviour
{
    public Transform container;
    public Transform spawner;
    public Rupee rupeePrefab;
    public float delay = 1f;

    private List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    private void StopSpawning()
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
        _rupees.Add(rupee);
    }
}