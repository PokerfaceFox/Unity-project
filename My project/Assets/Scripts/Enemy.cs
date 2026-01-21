using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private Vector2 _movementDirection;

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
        transform.Translate(_movementDirection * _speed * Time.deltaTime);
    }
}