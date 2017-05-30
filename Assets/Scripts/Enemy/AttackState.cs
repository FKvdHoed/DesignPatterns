using UnityEngine;

public class AttackState : AState {
    private static int sHPMin = 10;
    private static float sDistanceMax = 100;

    public IState PatrolState { get; set; }
    public IState FleeState { get; set; }

    public AttackState(IStateMachine stateMachine, Ship ship) : base(stateMachine, ship) { }

    public override void Update() {
        if(switchState())
            return;

        PlayerControls player = GameObject.FindObjectOfType<PlayerControls>();
        if(player == null)
            return;
        
        Vector3 direction = GameObject.transform.position - player.transform.position;
        mShip.RotateTowards(direction);
        mShip.Trust();

        mShip.Shoot();
    }

    private bool switchState() {
        if(mShip.Health <= sHPMin) {
            mStateMachine.SetState(FleeState);
            return true;
        }
        else {
            PlayerControls player = GameObject.FindObjectOfType<PlayerControls>();
            if(player == null)
                return false;

            if(sDistanceMax <= (GameObject.transform.position - player.transform.position).magnitude) {
                mStateMachine.SetState(PatrolState);
                return true;
            }
        }

        return false;
    }
}
