using UnityEngine;

// Source: http://www.unitygeek.com/unity_c_singleton/

// We made a generic class of Class type Component.
public class GenericSingletonClass<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // These lines will determine if an instance of the specified component already exists, 
                // if not it will create one and attach itself to the newly created GameObject. 
                // This means the component does not have to exist in the scene before hand. 
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        // Here lazy initialization is used so the instance is never NULL and only initialized when needed. 
        // It will also persist throughout scenes as it won’t be destroyed on load.
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
