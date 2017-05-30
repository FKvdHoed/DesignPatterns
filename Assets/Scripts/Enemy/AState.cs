using System;
using UnityEngine;

public abstract class AState : IState {
    protected bool mActive;
    protected Ship mShip;

    public AState(Ship ship) {
        mShip = ship;
    }

    public virtual bool Enter() {
        if(!mActive) {
            mActive = true;
            return true;
        } else
            return false;
    }

    public virtual bool Exit() {
        if(mActive) {
            mActive = false;
            return true;
        } else
            return false;
    }

    public abstract void Update();
}
