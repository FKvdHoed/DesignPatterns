using System;
using UnityEngine;

public abstract class AState : IState {
    protected Ship mShip;

    protected GameObject GameObject { get { return mShip.gameObject; } }

    public AState(Ship ship) {
        mShip = ship;
    }

    public abstract void Handle(IStateContext context);
}
