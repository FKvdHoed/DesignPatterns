using UnityEngine;

[DisallowMultipleComponent]
public class Builder : MonoBehaviour {
    private static Builder sInstance;

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

    public static GameObject BuildShip() {
    public static GameObject BuildPlayerShip() {
        GameObject go = sInstance.buildShip(sInstance.mPlayerSprite, sInstance.mPlayerValues);
        go.AddComponent<PlayerControls>();
        return go;
    }

    public static GameObject BuildEnemyShip() {
        GameObject go = sInstance.buildShip(sInstance.mEnemySprite, sInstance.mEnemyValues);
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
