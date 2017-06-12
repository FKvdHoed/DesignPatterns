using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://www.raywenderlich.com/136091/object-pooling-unity

// The ObjectPoolItem is a model for an Object that be can initialized using the ObjectPool. 
// Using amountToPool you can define the amount of Instances that needs to be created at startup.
[System.Serializable]
public class ObjectPoolItem { 
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand; }

// The ObjectPool is a Singleton and therefore inherits our GenericSingletonClass.
public class ObjectPool : GenericSingletonClass<ObjectPool> { 
    // List of all GameObjects inside the ObjectPool
    private List<GameObject> pooledObjects;

    [SerializeField]
    // Different types of GameObjects that can be initialized inside Editor (Bullet, Enemies etc.)
    private List<ObjectPoolItem> itemsToPool;

    /* 
     * Sample Implementation
     * ObjectPool.Instance.GetPooledObject(GameObject.tag);
    }*/

    // Use this for initialization
    void Start() {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                // The Unity Game object will be set inactive until it is actually used.
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }        }    }
    // Get a single pooled object, if the pool is contains no more non-active object and the pool is expandable it creates new instance.
    public GameObject GetPooledObject(string tag) {
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
                }            }
        }        return null;    }}
