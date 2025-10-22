using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public Cube[] SpawnCubes(Cube originalCube, int count, float scaleReductionMultiplier)
    {
        Cube[] newCubes = new Cube[count];
        Vector3 spawnPosition = originalCube.Position;
        Vector3 newScale = originalCube.Scale / scaleReductionMultiplier;

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, spawnPosition, Random.rotation);
            newCube.transform.localScale = newScale;
            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            newCubes[i] = newCube;
        }

        return newCubes;
    }
}