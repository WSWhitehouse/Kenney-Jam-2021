using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 spawnTimeRange = new Vector2(0.5f, 3.0f);
    [SerializeField] private GameObjectPool asteroidPool;

    private float _timer = 0f;

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0.0f)
        {
            Spawn();
            _timer = Random.Range(spawnTimeRange.x, spawnTimeRange.y);
        }
    }

    private void Spawn()
    {
        var camBounds = CameraBounds.Instance.Bounds;
        var asteroid = asteroidPool.GetPooledObject().GetComponent<Asteroid>();

        int side = Random.Range(0, 4);
        Vector3 pos = Vector3.zero;
        
        switch (side)
        {
            case 0: // top
            {
                pos.x = Random.Range(-camBounds.extents.x, camBounds.extents.x);
                pos.y = camBounds.extents.y;
                break;
            }

            case 1: // bottom
            {
                pos.x = Random.Range(-camBounds.extents.x, camBounds.extents.x);
                pos.y = -camBounds.extents.y;
                break;
            }

            case 2: // left
            {
                pos.x = -camBounds.extents.x;
                pos.y = Random.Range(-camBounds.extents.y, camBounds.extents.y);
                break;
            }

            case 3: // right
            {
                pos.x = camBounds.extents.x;
                pos.y = Random.Range(-camBounds.extents.y, camBounds.extents.y);
                break;
            }

            default:
                Debug.Log("bad");
                return;
        }
        
        asteroid.transform.position = pos;
        asteroid.StartMovement();
    }
}