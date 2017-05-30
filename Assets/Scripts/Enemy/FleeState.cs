using UnityEngine;

[RequireComponent(typeof(Ship))]
public class FleeState : AState {
    public static int sHPTreshholdPatrol = 50;
    public static float sSaveDistance = 100;

    private IState mNextState;

    public FleeState(IStateMachine stateMachine, IState nextState, Ship ship) : base(stateMachine, ship) {
        mNextState = nextState;
    }

    public override void Update() {
        PlayerControls player = GameObject.FindObjectOfType<PlayerControls>();
        if(player == null)
            return;

        Vector3 playerPos = player.transform.position;
        Vector3 direction = GameObject.transform.position - playerPos;
        if(sSaveDistance < direction.magnitude && sHPTreshholdPatrol <= mShip.Health)
            mStateMachine.SetState(mNextState);
        else {
            mShip.RotateTowards(direction);
            mShip.Trust();
        }
    }
}
