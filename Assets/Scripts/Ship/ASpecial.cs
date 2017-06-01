using UnityEngine;

[DisallowMultipleComponent]
public abstract class ASpecial : MonoBehaviour {
    protected Timer mCooldownTimer;
    
    protected abstract void Start();
    protected abstract void cooldownFeedback();
    public abstract void Activate();
	
	protected virtual void Update () {
        float percentage = mCooldownTimer.Update();
        // give feetback
    }
}
