using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;

    [Range(5f, 30f)]   
    public float speed = 10f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Debug.Log("start");
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _movement * speed;
    }
}