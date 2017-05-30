using UnityEngine;

[RequireComponent(typeof(Ship))]
public class FleeState : AState {
    public static int sHPTreshholdPatrol = 50;
    public static float sSaveDistance = 100;

    public IState NextState { get; set; }

    public FleeState(IStateMachine stateMachine, Ship ship) : base(stateMachine, ship) { }

    public override void Update() {
        PlayerControls player = GameObject.FindObjectOfType<PlayerControls>();
        if(player == null)
            return;

        Vector3 playerPos = player.transform.position;
        Vector3 direction = GameObject.transform.position - playerPos;
        if(sSaveDistance < direction.magnitude && sHPTreshholdPatrol <= mShip.Health)
            mStateMachine.SetState(NextState);
        else {
            mShip.RotateTowards(direction);
            mShip.Trust();
        }
    }
}
