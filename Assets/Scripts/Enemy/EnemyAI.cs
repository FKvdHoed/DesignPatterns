using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ship))]
public class EnemyAI : MonoBehaviour {
    private PatrolState mPatrolState;

    private IState mCurrentState;
    public IState CurrentState {
        get { return mCurrentState; }
        set {
            mCurrentState.Exit();
            mCurrentState = value;
            mCurrentState.Enter();
        }
    }
    
    void Start () {
        mPatrolState = new PatrolState(GetComponent<Ship>());
        mPatrolState.Enter();
        mCurrentState = mPatrolState;
	}

    void Update() {
        CurrentState.Update();
    } 
}
