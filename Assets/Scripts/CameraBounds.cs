using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBounds : MonoBehaviour
{
    // Singleton (sorry)
    public static CameraBounds Instance;

    private Camera _camera;

    public Bounds Bounds { get; private set; }

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void OnEnable()
    {
        float height = _camera.orthographicSize * 2.0f;
        float width = (_camera.aspect * _camera.orthographicSize) * 2.0f;
        float depth = _camera.farClipPlane - _camera.nearClipPlane;

        Vector3 centerPos = transform.position;
        centerPos.z += depth;

        Bounds = new Bounds(centerPos, new Vector3(width, height, depth));
    }
}