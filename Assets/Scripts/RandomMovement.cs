using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public float speed = 0f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        var x = Random.Range(-1f, 1f);
        var y = Random.Range(-1f, 1f);
        var movement = new Vector2(x, y).normalized;
        _rigidbody2D.velocity = movement * speed;
    }
}