using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private Transform _spawnArea;
    [SerializeField] private float _spawnInterval = 0.5f;
    [SerializeField] private float _spawnHeight = 10f;

    private float _timer;

    private void Start()
    {
        if (_spawnArea == null)
            _spawnArea = transform;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            SpawnCube();
            _timer = 0f;
        }
    }

    private void SpawnCube()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Cube cube = _cubePool.GetCube();

        cube.transform.position = spawnPosition;
        cube.transform.rotation = Quaternion.identity;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 areaSize = _spawnArea.localScale;
        Vector3 areaPosition = _spawnArea.position;

        float sizeDivider = 2f;
        float halfSizeX = areaSize.x / sizeDivider;
        float halfSizeZ = areaSize.z / sizeDivider;

        float randomX = Random.Range(-halfSizeX, halfSizeX);
        float randomZ = Random.Range(-halfSizeZ, halfSizeZ);

        return new Vector3(
            areaPosition.x + randomX,
            areaPosition.y + _spawnHeight,
            areaPosition.z + randomZ
        );
    }
}
