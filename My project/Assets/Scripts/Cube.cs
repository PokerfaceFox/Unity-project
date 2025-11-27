using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    private Rigidbody _rigidbody;

    public float SplitChance { get; set; } = 1f;
    public Rigidbody PhysicsBody => _rigidbody;
    public Vector3 Center => transform.position;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_renderer == null)
            _renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        Clicked();
    }

    public void ApplyVisuals(Color color, Vector3 scale)
    {
        transform.localScale = scale;

        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.color = color;
        _renderer.material = newMaterial;
    }

    public void Clicked()
    {
        Clicking?.Invoke(this);
    }

    public event Action<Cube> Clicking;
}