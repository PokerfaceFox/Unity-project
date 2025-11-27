using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;

    public void ApplyToCubes(Cube[] cubes, Vector3 explosionCenter)
    {
        foreach (Cube cube in cubes)
        {
            Rigidbody rigidbody = cube.PhysicsBody;

            rigidbody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
        }
    }
}