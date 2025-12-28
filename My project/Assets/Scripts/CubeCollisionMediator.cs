using UnityEngine;

public class CubeCollisionMediator : MonoBehaviour
{
    private Cube _cube;
    private CubeCollisionHandler _collisionHandler;

    private void OnEnable()
    {
        _cube = GetComponent<Cube>();
        _collisionHandler = GetComponent<CubeCollisionHandler>();

        if (_cube != null && _collisionHandler != null)
        {
            _collisionHandler.PlatformCollisionOccurred += _cube.NotifyPlatformTouch;
        }
    }

    private void OnDisable()
    {
        if (_cube != null && _collisionHandler != null)
        {
            _collisionHandler.PlatformCollisionOccurred -= _cube.NotifyPlatformTouch;
        }
    }
}