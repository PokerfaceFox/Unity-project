using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public Cube Create(Vector3 position, Vector3 scale, Color color, float splitChance)
    {
        Cube newCube = Instantiate(_cubePrefab, position, Quaternion.identity);

        newCube.ApplyVisuals(color, scale);
        newCube.SplitChance = splitChance;

        return newCube;
    }

    public void Remove(Cube cube)
    {
        if (cube != null)
            Destroy(cube.gameObject);
    }
}