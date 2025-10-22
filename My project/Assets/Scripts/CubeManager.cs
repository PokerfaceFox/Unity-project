using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [Header("Split Settings")]
    [SerializeField] private float _initialSplitChance = 1f;
    [SerializeField] private int _minCubesOnSplit = 2;
    [SerializeField] private int _maxCubesOnSplit = 6;
    [SerializeField] private float _scaleReductionMultiplier = 2f;
    [SerializeField] private float _chanceReductionMultiplier = 2f;

    [Header("Explosion Settings")]
    [SerializeField] private float _explosionForce = 10f;

    [Header("References")]
    [SerializeField] private CubeSpawner _spawner;

    private float _currentSplitChance;

    private void Start()
    {
        _currentSplitChance = _initialSplitChance;

        Cube[] existingCubes = FindObjectsOfType<Cube>();

        foreach (Cube cube in existingCubes)
        {
            cube.OnClicked += HandleCubeClick;
        }
    }

    private void HandleCubeClick(Cube clickedCube)
    {
        clickedCube.OnClicked -= HandleCubeClick;
        clickedCube.DestroyCube();

        bool shouldSplit = Random.Range(0f, 1f) <= _currentSplitChance;

        if (shouldSplit)
        {
            int newCubeCount = Random.Range(_minCubesOnSplit, _maxCubesOnSplit + 1);
            Cube[] newCubes = _spawner.SpawnCubes(clickedCube, newCubeCount, _scaleReductionMultiplier);

            foreach (Cube newCube in newCubes)
            {
                Rigidbody rb = newCube.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Vector3 randomDirection = Random.onUnitSphere;
                    rb.AddForce(randomDirection * _explosionForce, ForceMode.Impulse);
                }

                newCube.OnClicked += HandleCubeClick;
            }

            _currentSplitChance /= _chanceReductionMultiplier;
        }
    }
}