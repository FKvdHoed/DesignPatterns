public class Camouflage : ASpecial {
    protected override void Start() {
        mCooldownTimer = new Timer(GetComponent<AEngine>().Power / GetComponent<Ship>().Mass);
    }

    public override void Activate() {
        if(!mCooldownTimer.Active)
            UnityEngine.Debug.LogWarning("implment camouflage");
    }

    protected override void cooldownFeedback() {}
}
