using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    public event Action<Cube> OnClicked;

    public Vector3 Position => transform.position;
    public Vector3 Scale => transform.localScale;
    public Rigidbody Rigidbody => GetComponent<Rigidbody>();

    private void OnMouseDown()
    {
        OnClicked?.Invoke(this);
    }

    public void DestroyCube()
    {
        Destroy(gameObject);
    }
}