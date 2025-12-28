using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    public event Action PlatformTouched;
    public event Action LifeEnded;

    private Action<Cube> _returnToPoolCallback;
    private bool _hasTouchedPlatform;

    public void Initialize(Action<Cube> returnCallback)
    {
        _hasTouchedPlatform = false;
        _returnToPoolCallback = returnCallback;
    }

    public void NotifyPlatformTouch()
    {
        if (!_hasTouchedPlatform)
        {
            _hasTouchedPlatform = true;
            PlatformTouched?.Invoke();
        }
    }

    public void NotifyLifeEnded()
    {
        LifeEnded?.Invoke();
        _returnToPoolCallback?.Invoke(this);
    }
}