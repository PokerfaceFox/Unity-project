using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer), typeof(ColorChanger))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private ColorChanger _colorChanger;
    private Rigidbody _rigidbody;

    public float SplitChance { get; set; } = 1f;
    public Rigidbody PhysicsBody => _rigidbody;
    public Vector3 Center => transform.position;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_renderer == null)
            _renderer = GetComponent<Renderer>();

        if (_colorChanger == null)
            _colorChanger = GetComponent<ColorChanger>();
    }

    private void OnMouseDown()
    {
        Clicked();
    }

    public void ApplyVisuals(Color color, Vector3 scale)
    {
        transform.localScale = scale;
        _colorChanger.ApplyColor(color);
    }

    public void Clicked()
    {
        Clicking?.Invoke(this);
    }

    public event Action<Cube> Clicking;
}