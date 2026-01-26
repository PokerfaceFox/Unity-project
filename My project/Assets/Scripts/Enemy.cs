using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private Vector2 _movementDirection;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 spawnPosition, Vector2 movementDirection)
    {
        transform.position = spawnPosition;
        _movementDirection = movementDirection.normalized;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_movementDirection != Vector2.zero)
        {
            _rigidbody.velocity = _movementDirection * _speed;

            if (_movementDirection.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (_movementDirection.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}