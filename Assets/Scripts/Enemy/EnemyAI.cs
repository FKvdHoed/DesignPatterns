using System;
using UnityEngine;

[RequireComponent(typeof(Ship))]
public class EnemyAI : MonoBehaviour, IStateContext {
    private IState mCurrentState;
    
    void Start () {
        Ship ship = GetComponent<Ship>();
        mCurrentState = new FleeState(ship);
	}

    void Update() {
        Request();
    }

    public void Request() {
        mCurrentState.Handle(this);
    }

    public void SetState(IState value) {
        mCurrentState = value;
    }
}
