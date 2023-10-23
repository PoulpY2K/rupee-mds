using System;
using UnityEngine;

public class Rupee : MonoBehaviour
{
    public event Action<Rupee> OnCollected;

    public int score = 0;

    private RupeeData _data;

    private SpriteRenderer _sr;

    private RandomMovement _rm;

    public Light pointLight;

    public ParticleSystem particle;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rm = GetComponent<RandomMovement>();
    }

    public RupeeData Data
    {
        get => _data;
        set
        {
            _data = value;
            score = _data.score;
            _sr.color = _data.color;
            _rm.speed = _data.speed;
            pointLight.color = _data.color;
            var pParticle = particle.main;
            pParticle.startColor = _data.color;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollected?.Invoke(this);
        }
    }
}