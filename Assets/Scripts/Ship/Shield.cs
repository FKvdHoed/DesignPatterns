public class Shield : ASpecial {
    protected override void Start() {
        mCooldownTimer = new Timer(GetComponent<AEngine>().Power / GetComponent<Ship>().Mass);
    }

    protected override void cooldownFeedback() {}

    public override void Activate() {
        if(!mCooldownTimer.Active)
            UnityEngine.Debug.LogWarning("implment shield");
    }
}
