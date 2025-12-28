using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    public bool HasTouchedPlatform { get; private set; }

    public event Action<Cube> PlatformTouched;

    public void Initialize()
    {
        HasTouchedPlatform = false;
    }

    public void TouchPlatform()
    {
        if (HasTouchedPlatform == false)
        {
            HasTouchedPlatform = true;
            PlatformTouched?.Invoke(this);
        }
    }
}
