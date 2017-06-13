using UnityEngine;

public class ShipFactory {
    private static ShipFactory sInstance;
    public static ShipFactory GetInstance() {
        if(sInstance == null)
            sInstance = new ShipFactory();

        return sInstance;
    }

    private GameObject mEnemyCruiserMayor;
    private GameObject mEnemyCruiserTactic;
    private GameObject mEnemyCruiserMinor;
    
    private ShipFactory() {
        ShipDirector director = new ShipDirector();

        IBuildShipBehavior battleShipBehavior = new BuildBattleShipBehavior();
        IBuildShipBehavior cruiserBehavior = new BuildCruiserBehavior();
        IBuildShipBehavior DestroyerBehavior = new BuildDestroyerBehavior();

        IBuildWeaponbayBehavior bulletBehavior = new BuildBulletBehavior();
        IBuildWeaponbayBehavior lazerBehavior = new BuildLazerBehavior();

        IBuildEngineBehavior teleportBehavior = new BuildTeleportBehavior();
        IBuildEngineBehavior trustBehavior = new BuildTrustBehavior();

        IBuildSpecialBehavior camouflageBehavior = new BuildCamouflagedBehavior();
        IBuildSpecialBehavior shieldBehavior = new BuildShieldBehavior();
        IBuildSpecialBehavior nospecialBehavior = new BuildNoSpecialBehavior();

        IBuildControllerBehavior aiBehavior = new BuildAIBehavior();
        IBuildControllerBehavior playerBehavior = new BuildPlayerBehavior();

        ConcreteBuilder builder = new ConcreteBuilder();
        
        builder.ShipBehavior = cruiserBehavior;
        builder.WeaponbayBehavior = bulletBehavior;
        builder.EngineBehavior = trustBehavior;
        builder.SpecialBehavior = nospecialBehavior;
        builder.ControllerBehavior = aiBehavior;
        director.Construct(builder);
        mEnemyCruiserMinor = builder.GetResult();
        
        builder.SpecialBehavior = shieldBehavior;
        director.Construct(builder);
        mEnemyCruiserMayor = builder.GetResult();

        builder.EngineBehavior = teleportBehavior;
        builder.SpecialBehavior = camouflageBehavior;
        director.Construct(builder);
        mEnemyCruiserTactic = builder.GetResult();
    }

    public GameObject createEnemyCruiserMinor() {
        return GameObject.Instantiate(mEnemyCruiserMinor);
    }
    public GameObject createEnemyCruiserMayor() {
        return GameObject.Instantiate(mEnemyCruiserMayor);
    }

    public GameObject createEnemyCruiserTactic() {
        return GameObject.Instantiate(mEnemyCruiserTactic);
    }
    private class ShipDirector {
        public void Construct(AShipBuilder builder) {
            builder.BuildBase();
            builder.BuildShip();
            builder.BuildWeaponbay();
            builder.BuildEngine();
            builder.BuildSpecial();
            builder.BuildController();
        }
    }
}
