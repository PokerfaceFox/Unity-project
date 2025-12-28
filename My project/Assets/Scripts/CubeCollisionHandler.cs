using UnityEngine;

public class CubeCollisionHandler : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") && _cube.HasTouchedPlatform == false)
        {
            _cube.TouchPlatform();
        }
    }
}
