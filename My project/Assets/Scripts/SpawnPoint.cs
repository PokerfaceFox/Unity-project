using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Vector2 _spawnDirection = Vector2.left;

    public Vector2 Position => transform.position;
    public Vector2 Direction => _spawnDirection;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.3f);
        Gizmos.DrawRay(transform.position, _spawnDirection);
    }
}