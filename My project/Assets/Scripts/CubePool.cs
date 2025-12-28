using UnityEngine;
using System.Collections.Generic;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _initialPoolSize = 20;

    private Queue<Cube> _pool = new Queue<Cube>();
    private Transform _poolContainer;

    private void Awake()
    {
        _poolContainer = new GameObject("PoolContainer").transform;
        _poolContainer.SetParent(transform);

        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < _initialPoolSize; i++)
        {
            CreateNewCube();
        }
    }

    private void CreateNewCube()
    {
        Cube cube = Instantiate(_cubePrefab, _poolContainer);
        cube.gameObject.SetActive(false);
        cube.Initialize();
        _pool.Enqueue(cube);
    }

    public Cube GetCube()
    {
        if (_pool.Count == 0)
        {
            CreateNewCube();
        }

        Cube cube = _pool.Dequeue();
        cube.gameObject.SetActive(true);
        cube.Initialize();

        SubscribeToCubeEvents(cube);

        return cube;
    }

    public void ReturnCube(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.transform.SetParent(_poolContainer);
        cube.transform.localPosition = Vector3.zero;
        _pool.Enqueue(cube);
    }

    private void SubscribeToCubeEvents(Cube cube)
    {
        CubeLifeTimer lifeTimer = cube.GetComponent<CubeLifeTimer>();

        if (lifeTimer != null)
        {
        }

        ColorChanger colorChanger = cube.GetComponent<ColorChanger>();

        if (colorChanger != null)
        {
        }
    }
}