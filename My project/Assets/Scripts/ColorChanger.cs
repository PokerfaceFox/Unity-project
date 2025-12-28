using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _initialColor = Color.blue;
    [SerializeField] private Color _touchColor = Color.green;
    private const string StandardShaderName = "Standard";

    private void Awake()
    {
        if (_renderer == null)
            _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        _cube.PlatformTouched += OnPlatformTouched;
        ApplyInitialColor();
    }

    public void ApplyInitialColor()
    {
        ApplyColor(_initialColor);
    }

    private void OnPlatformTouched(Cube cube)
    {
        ApplyColor(_touchColor);
    }

    public void ApplyColor(Color color)
    {
        Material newMaterial = new Material(Shader.Find(StandardShaderName));
        newMaterial.color = color;
        _renderer.material = newMaterial;
    }
}