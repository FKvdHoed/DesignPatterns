using UnityEngine;

[DisallowMultipleComponent]
public class Builder : MonoBehaviour {
    private static Builder sInstance;
    public static Builder Instance { get { return sInstance; } }

    [Header("Player Ship")]
    [SerializeField]
    private Sprite mPlayerSprite;
    [SerializeField]
    private Ship.SValues mPlayerValues;

    [Header("Enemy Ship")]
    [SerializeField]
    private Sprite mEnemySprite;
    [SerializeField]
    private Ship.SValues mEnemyValues;
    
    void Awake() {
        if(sInstance == null)
            sInstance = this;
        else if(sInstance !=this)
            Destroy(gameObject);
    }
    
    public GameObject BuildPlayerShip() {
        GameObject go = buildShip(mPlayerSprite, mPlayerValues);
        go.AddComponent<PlayerControls>();
        return go;
    }

    public GameObject BuildEnemyShip() {
        GameObject go = buildShip(mEnemySprite, mEnemyValues);
        go.AddComponent<EnemyAI>();
        return go;
    }

    private GameObject buildShip(Sprite sprite, Ship.SValues values) {
        GameObject go = new GameObject();

        go.AddComponent<Rigidbody>().useGravity = false;
        go.AddComponent<SpriteRenderer>().sprite = sprite;
        go.AddComponent<Ship>().SetValues(values);

        return go;
    }
}
