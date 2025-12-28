using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    public bool HasTouchedPlatform { get; private set; }
    public event Action<Cube> PlatformTouched;

    private Action<Cube> _onLifeEnded;

    public void Initialize(Action<Cube> onLifeEnded = null)
    {
        HasTouchedPlatform = false;
        _onLifeEnded = onLifeEnded;
    }

    public void TouchPlatform()
    {
        if (!HasTouchedPlatform)
        {
            HasTouchedPlatform = true;
            PlatformTouched?.Invoke(this);
        }
    }

    public void NotifyLifeEnded()
    {
        _onLifeEnded?.Invoke(this);
    }
}