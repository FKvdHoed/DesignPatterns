using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.raywenderlich.com/136091/object-pooling-unity

[System.Serializable]
public class ObjectPoolItem
{
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand;
}

public abstract class ObjectPool : MonoBehaviour
{
    private static ObjectPool myInstance;

    // List of all GameObjects inside the ObjectPool
    private List<GameObject> pooledObjects;

    [SerializeField]
    // Different types of GameObjects that can be initialized inside Editor (Bullet, Enemies etc.)
    private List<ObjectPoolItem> itemsToPool;

    public static ObjectPool getInstance()
    {
        return myInstance;
    }

    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

    void Awake()
    {
        myInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
