using UnityEngine;

public class CubeCollisionHandler : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out _) && _cube.HasTouchedPlatform == false)
        {
            _cube.TouchPlatform();
        }
    }
}