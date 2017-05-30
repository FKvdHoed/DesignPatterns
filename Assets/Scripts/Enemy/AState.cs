using System;
using UnityEngine;

public abstract class AState : IState {
    protected Ship mShip;
    protected IStateMachine mStateMachine;

    protected GameObject GameObject { get { return mShip.gameObject; } }

    public AState(IStateMachine stateMachine, Ship ship) {
        mStateMachine = stateMachine;
        mShip = ship;
    }

    public abstract void Update();
}
