using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private float _timer;
    private const float TimerResetValue = 0f;

    private void Start()
    {
        if (_spawnPoints.Count == 0)
        {
            FindAllSpawnPoints();
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            SpawnEnemy();
            _timer = TimerResetValue;
        }
    }

    private void SpawnEnemy()
    {
        if (_spawnPoints.Count == 0) return;

        SpawnPoint randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

        Enemy newEnemy = Instantiate(_enemyPrefab);
        newEnemy.Setup(randomSpawnPoint.Position, randomSpawnPoint.Direction);
    }

    private void FindAllSpawnPoints()
    {
        SpawnPoint[] foundPoints = FindObjectsOfType<SpawnPoint>();
        _spawnPoints = new List<SpawnPoint>(foundPoints);

        if (_spawnPoints.Count == 0)
        {
            Debug.LogWarning("No spawn points found! Create SpawnPoint objects in scene.");
        }
    }
}