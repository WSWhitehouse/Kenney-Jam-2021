using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    public List<GameObject> pool = new List<GameObject>();
    public int amountToInitiallyPool = 10;
    [SerializeField] private GameObject objectToPool;

    private void Awake()
    {
        for (int i = 0; i < amountToInitiallyPool; i++)
        {
            CreateNewPooledObject();
        }
    }

    private GameObject CreateNewPooledObject()
    {
        GameObject tmp = Instantiate(objectToPool);
        tmp.SetActive(false);
        pool.Add(tmp);
        return tmp;
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject pooledObject in pool.Where(go => !go.activeInHierarchy))
        {
            pooledObject.SetActive(true);
            return pooledObject;
        }

        GameObject tmp = CreateNewPooledObject();
        tmp.SetActive(true);
        return tmp;
    }
}