using System;
using UnityEngine;

[RequireComponent(typeof(Ship))]
public class EnemyAI : MonoBehaviour, IStateContext {
    private IState mCurrentState;
    
    void Start () {
        Ship ship = GetComponent<Ship>();
        PatrolState patrolState = new PatrolState(this, ship);
        FleeState fleeState = new FleeState(this, ship);
        AttackState attackState = new AttackState(this, ship);
        
        patrolState.NextState = attackState;
        fleeState.NextState = patrolState;
        attackState.FleeState = fleeState;
        attackState.PatrolState = patrolState;

        mCurrentState = fleeState;
	}

    void Update() {
        Request();
    }

    public void Request() {
        mCurrentState.Handle();
    }

    public void SetState(IState value) {
        mCurrentState = value;
    }
}
