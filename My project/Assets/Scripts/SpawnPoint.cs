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
        Vector3 spawnPosition = transform.position;
        Enemy newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);

        Vector2 targetPos = _target.transform.position;
        Vector2 direction = (targetPos - (Vector2)spawnPosition).normalized;

        newEnemy.Setup(spawnPosition, direction);
    }
}