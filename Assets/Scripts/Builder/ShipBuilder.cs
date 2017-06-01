using UnityEngine;

class ShipBuilder {
    private GameObject mProduct;

    public IBuildShipBehavior ShipBehavior { get; set; }
    public IBuildWeaponbayBehavior WeaponbayBehavior { get; set; }
    public IBuildEngineBehavior EngineBehavior { get; set; }
    public IBuildSpecialBehavior SpecialBehavior { get; set; }
    public IBuildControllerBehavior ControllerBehavior { get; set; }

    public void BuildBase() {
        mProduct = new GameObject();
        mProduct.AddComponent<Rigidbody>().useGravity = false;
    }
    public void BuildShip() {
        ShipBehavior.Build(mProduct.AddComponent<Ship>());
    }
    public void BuildWeaponbay() {
        WeaponbayBehavior.Build(mProduct.GetComponent<Ship>().Weaponbay);
    }
    public void BuildEngine() {
        EngineBehavior.Build(mProduct);
    }
    public void BuildSpecial() {
        SpecialBehavior.Build(mProduct);
    }
    public void BuildController() {
        ControllerBehavior.Build(mProduct);
    }

    public GameObject GetResult() {
        return mProduct;
    }
}

#region Build Ship Behavior
public interface IBuildShipBehavior {
    void Build(Ship ship);
}
public class BuildDestroyerBehavior : IBuildShipBehavior {
    public void Build(Ship ship) {
        ship.Stearing = 0;
        ship.Mass = 0;
        ship.Weaponbay = new Turret[0];

        SpriteRenderer renderer = ship.gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>("");

        Debug.LogWarning("add health component");
        // Health health = ship.gameObject.AddComponent<Health>();
        // health.HP = 0;
    }
}
public class BuildBattleShipBehavior : IBuildShipBehavior {
    public void Build(Ship ship) {
        ship.Stearing = 0;
        ship.Mass = 0;
        ship.Weaponbay = new Turret[0];

        SpriteRenderer renderer = ship.gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>("");

        Debug.LogWarning("add health component");
        // Health health = ship.gameObject.AddComponent<Health>();
        // health.HP = 0;
    }
}
public class BuildCruiserBehavior : IBuildShipBehavior {
    public void Build(Ship ship) {
        ship.Stearing = 0;
        ship.Mass = 0;
        ship.Weaponbay = new Turret[0];

        SpriteRenderer renderer = ship.gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>("");

        Debug.LogWarning("add health component");
        // Health health = ship.gameObject.AddComponent<Health>();
        // health.HP = 0;
    }
}
#endregion
#region Build Weaponbay Behavior
interface IBuildWeaponbayBehavior {
    void Build(Turret[] weaponbay);
}
public class BuildLazerBehavior : IBuildWeaponbayBehavior {
    public void Build(Turret[] weaponbay) {
        for(int i = 0;i < weaponbay.Length;++i)
            weaponbay[i] = new LazerTurret();
    }
}
public class BuildBulletBehavior : IBuildWeaponbayBehavior {
    public void Build(Turret[] weaponbay) {
        for(int i = 0;i < weaponbay.Length;++i)
            weaponbay[i] = new BulletTurret();
    }
}
#endregion
#region Build Engine Behavior
public interface IBuildEngineBehavior {
    void Build(GameObject product);
}
public class BuildTrustBehavior : IBuildEngineBehavior {
    public void Build(GameObject product) {
        TrustEngine engine = product.AddComponent<TrustEngine>();
        engine.Power = 0;
    }
}
public class BuildTeleportBehavior : IBuildEngineBehavior {
    public void Build(GameObject product) {
        TeleportEngine engine = product.AddComponent<TeleportEngine>();
        engine.Power = 0;
    }
}
#endregion
#region Build Special Behavior
public interface IBuildSpecialBehavior {
    void Build(GameObject product);
}
public class BuildShieldBehavior : IBuildSpecialBehavior {
    public void Build(GameObject product) {
        product.AddComponent<Shield>();
    }
}
public class BuildCamouflagedBehavior : IBuildSpecialBehavior {
    public void Build(GameObject product) {
        product.AddComponent<Camouflage>();
    }
}
public class BuildNoSpecialBehavior : IBuildSpecialBehavior {
    public void Build(GameObject product) {
        product.AddComponent<NullSpecial>();
    }
}
#endregion
#region Build Controller Behavior
public interface IBuildControllerBehavior {
    void Build(GameObject product);
}
public class BuildPlayerBehavior : IBuildControllerBehavior {
    public void Build(GameObject product) {
        product.AddComponent<PlayerControls>();
    }
}
public class BuildAIBehavior : IBuildControllerBehavior {
    public void Build(GameObject product) {
        product.AddComponent<EnemyAI>();
    }
}
#endregion