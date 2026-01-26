using UnityEngine;
using System.Collections.Generic;

public class Target : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _moveSpeed = 2f;

    private int _currentIndex = 0;

    private void Start()
    {
        if (_waypoints.Count > 0)
        {
            transform.position = _waypoints[0].position;
        }
    }

    private void Update()
    {
        if (_waypoints.Count == 0) return;

        Transform currentWaypoint = _waypoints[_currentIndex];
        transform.position = Vector2.MoveTowards(
            transform.position,
            currentWaypoint.position,
            _moveSpeed * Time.deltaTime
        );

        float distance = Vector2.Distance(transform.position, currentWaypoint.position);
        if (distance < 0.05f)
        {
            _currentIndex = (_currentIndex + 1) % _waypoints.Count;
        }
    }

    private void OnDrawGizmos()
    {
        if (_waypoints.Count > 1)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < _waypoints.Count - 1; i++)
            {
                if (_waypoints[i] != null && _waypoints[i + 1] != null)
                {
                    Gizmos.DrawLine(_waypoints[i].position, _waypoints[i + 1].position);
                }
            }

            if (_waypoints.Count > 2 && _waypoints[0] != null && _waypoints[^1] != null)
            {
                Gizmos.DrawLine(_waypoints[^1].position, _waypoints[0].position);
            }
        }

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}