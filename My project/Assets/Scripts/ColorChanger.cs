using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    private const string STANDARD_SHADER_NAME = "Standard";

    private void Awake()
    {
        if (_renderer == null)
            _renderer = GetComponent<Renderer>();
    }

    public void ApplyColor(Color color)
    {
        Material newMaterial = new Material(Shader.Find(STANDARD_SHADER_NAME));

        newMaterial.color = color;
        _renderer.material = newMaterial;
    }
}