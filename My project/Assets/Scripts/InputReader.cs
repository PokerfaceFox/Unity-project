using System;
using Unity.VisualScripting;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action OnToggleCounter;
    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
            OnToggleCounter?.Invoke();
    }
}
