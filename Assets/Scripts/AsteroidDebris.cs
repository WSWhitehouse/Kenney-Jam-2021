using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidDebris : MonoBehaviour
{
    // Singleton (sorry)
    public static AsteroidDebris Instance;

    [SerializeField] private int minDebris = 3;
    [SerializeField] private int maxDebris = 5;

    private GameObjectPool _pool;

    private void Awake()
    {
        _pool = GetComponent<GameObjectPool>();

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

    public void CreateDebris(Vector3 pos)
    {
        int amount = Random.Range(minDebris, maxDebris);

        for (int i = 0; i < amount; i++)
        {
            var debris = _pool.GetPooledObject().GetComponent<Debris>();
            debris.transform.position = pos;

            debris.StartScale();
        }
    }
}