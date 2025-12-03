using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private CubeFactory _factory;
    [SerializeField] private CubeExploder _exploder;
    [SerializeField] private CubeSplitCalculator _calculator;

    private void OnCubeClicking(Cube clickedCube)
    {
        bool shouldSplit = _calculator.ShouldSplit(clickedCube);

        if (shouldSplit)
        {
            SplitCube(clickedCube);
        }

        CreateExplosionFromCube(clickedCube);
        _factory.Remove(clickedCube);
    }

    private void CreateExplosionFromCube(Cube cube)
    {
        float cubeScale = cube.transform.localScale.x;

        _exploder.CreateExplosion(cube.Center, cubeScale);
    }

    private void SplitCube(Cube originalCube)
    {
        int minCubes = 2;
        int maxCubes = 6;
        int cubeCount = Random.Range(minCubes, maxCubes + 1);

        Vector3 newScale = _calculator.CalculateNewScale(originalCube.transform.localScale);
        float newSplitChance = _calculator.CalculateNewSplitChance(originalCube.SplitChance);

        Cube[] newCubes = new Cube[cubeCount];

        for (int i = 0; i < cubeCount; i++)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            Cube newCube = _factory.Create(originalCube.Center, newScale, randomColor, newSplitChance);

            newCubes[i] = newCube;
            newCube.Clicking += OnCubeClicking;
        }
    }

    private void Start()
    {
        Cube[] initialCubes = FindObjectsOfType<Cube>();

        foreach (Cube cube in initialCubes)
        {
            cube.Clicking += OnCubeClicking;
        }
    }
}