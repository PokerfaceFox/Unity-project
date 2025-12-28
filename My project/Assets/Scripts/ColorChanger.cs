using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _initialColor = Color.blue;
    [SerializeField] private Color _touchColor = Color.green;
    private const string StandardShaderName = "Standard";

    private Cube _cube;

    private void OnEnable()
    {
        _cube = GetComponent<Cube>();
        if (_cube != null)
        {
            _cube.PlatformTouched += HandlePlatformTouch;
        }

        ApplyColor(_initialColor);
    }

    private void OnDisable()
    {
        if (_cube != null)
        {
            _cube.PlatformTouched -= HandlePlatformTouch;
        }
    }

    private void HandlePlatformTouch()
    {
        ApplyColor(_touchColor);
    }

    private void ApplyColor(Color color)
    {
        Material newMaterial = new Material(Shader.Find(StandardShaderName));
        newMaterial.color = color;
        _renderer.material = newMaterial;
    }
}