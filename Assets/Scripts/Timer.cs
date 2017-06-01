using UnityEngine;

public class Timer {
    private float mCooldownTime;
    private float mTimerStart;

    public bool Active { get; private set; }

    public Timer(float cooldownTime) {
        mCooldownTime = cooldownTime;
    }

    public void Start() {
        mTimerStart = Time.time;
    }

    public float Update() {
        float passedTime = Time.time - mTimerStart;
        if(Active && mCooldownTime < passedTime) {
            Active = false;
            return 0;
        } else
            return passedTime / mCooldownTime;
    }
}