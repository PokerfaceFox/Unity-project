using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private const float ReachDistance = 0.05f;

    private Target _target;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_target == null) return;
        MoveToTarget();
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }

    private void MoveToTarget()
    {
        Vector2 direction = GetDirectionToTarget();
        ApplyMovement(direction);
        UpdateFacing(direction);
    }

    private Vector2 GetDirectionToTarget()
    {
        return ((Vector2)_target.transform.position - (Vector2)transform.position).normalized;
    }

    private void ApplyMovement(Vector2 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }

    private void UpdateFacing(Vector2 direction)
    {
        if (direction.x != 0)
        {
            float angle = direction.x > 0 ? 0f : 180f;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}