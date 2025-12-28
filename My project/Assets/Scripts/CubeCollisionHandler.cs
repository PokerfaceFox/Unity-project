using System;
using UnityEngine;

public class CubeCollisionHandler : MonoBehaviour
{
    public event Action PlatformCollisionOccurred;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out _))
        {
            PlatformCollisionOccurred?.Invoke();
        }
    }
}