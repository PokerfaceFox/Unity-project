using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _baseForce = 10f;
    [SerializeField] private float _baseRadius = 5f;
    private const float MIN_DISTANCE = 0.1f;

    public void CreateExplosion(Vector3 explosionCenter, float sourceCubeScale)
    {
        float explosionRadius = CalculateRadius(sourceCubeScale);

        Collider[] collidersInRadius = Physics.OverlapSphere(explosionCenter, explosionRadius);

        foreach (Collider collider in collidersInRadius)
        {
            TryApplyExplosionForce(collider, explosionCenter, sourceCubeScale, explosionRadius);
        }
    }

    private void TryApplyExplosionForce(Collider collider, Vector3 explosionCenter, float sourceCubeScale, float explosionRadius)
    {
        Cube cube = collider.GetComponent<Cube>();

        if (cube == null || cube.PhysicsBody == null) return;

        Rigidbody rigidbody = cube.PhysicsBody;
        Vector3 directionToCube = cube.transform.position - explosionCenter;
        float distance = directionToCube.magnitude;

        if (distance < MIN_DISTANCE) return;

        float force = CalculateForce(distance, explosionRadius, sourceCubeScale, cube.transform.localScale.x);

        rigidbody.AddForce(directionToCube.normalized * force, ForceMode.Impulse);
    }

    private float CalculateRadius(float cubeScale)
    {
        return _baseRadius / cubeScale;
    }

    private float CalculateForce(float distance, float explosionRadius, float sourceScale, float targetScale)
    {
        float distanceFactor = 1f - (distance / explosionRadius);
        float sourceScaleFactor = 1f / sourceScale;
        float targetScaleFactor = 1f / targetScale;

        return _baseForce * distanceFactor * sourceScaleFactor * targetScaleFactor;
    }
}