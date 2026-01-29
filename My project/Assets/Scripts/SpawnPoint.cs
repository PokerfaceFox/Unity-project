using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target _target;
    [SerializeField] private float _spawnInterval = 2f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            TrySpawnEnemy();
            _timer = 0f;
        }
    }

    private void TrySpawnEnemy()
    {
        if (_enemyPrefab == null)
        {
            Debug.LogWarning("Enemy prefab is not assigned!");
            return;
        }

        if (_target == null)
        {
            Debug.LogWarning("Target is not assigned!");
            return;
        }

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        newEnemy.SetTarget(_target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.2f);

        if (_target != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, _target.transform.position);
        }
    }
}