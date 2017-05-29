using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Builder : MonoBehaviour {
    private static Builder sInstance;

    [Header("Player Ship Settings")]
    [SerializeField]
    private Sprite mPlayerSprite;
    [SerializeField]
    private Ship.SValues mPlayerValues;

    void Awake() {
        if(sInstance == null)
            sInstance = this;
        else if(sInstance !=this)
            Destroy(gameObject);
    }

    public static GameObject BuildShip() {
        GameObject go = new GameObject();

        go.AddComponent<Rigidbody>().useGravity = false;
        go.AddComponent<SpriteRenderer>().sprite = sInstance.mPlayerSprite;
        go.AddComponent<Ship>().SetValues(sInstance.mPlayerValues);
        
        return go;
    }
}
