using System;
using UnityEngine;

[RequireComponent(typeof(Ship))]
public class EnemyAI : MonoBehaviour, IStateMachine {
    private IState mCurrentState;
    
    void Start () {
        Ship ship = GetComponent<Ship>();
        IState patrolState = new PatrolState(this, ship);
        IState fleeState = new FleeState(this, patrolState, ship);

        mCurrentState = fleeState;
	}

    void Update() {
        mCurrentState.Update();
    }

    public void SetState(IState value) {
        mCurrentState = value;
    }
}
