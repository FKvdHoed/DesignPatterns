public class TeleportEngine : AEngine {
    private Timer mCooldownTimer;

    void Start() {
        mCooldownTimer = new Timer(GetComponent<AEngine>().Power / GetComponent<Ship>().Mass);
    }
    
    void Update() {
        float percentage = mCooldownTimer.Update();
        // give feetback
    }

    public override void Move() {
        if(!mCooldownTimer.Active)
            UnityEngine.Debug.LogWarning("implment Teleport");
    }
}
