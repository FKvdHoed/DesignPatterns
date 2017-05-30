using UnityEngine;

[RequireComponent(typeof(Ship))]
public class PatrolState : AState {
    private static int viewRadius = 90;
    private static int viewDistance = 10;

    public IState NextState { get; set; }

    public PatrolState (IStateMachine stateMachine, Ship ship) : base(stateMachine, ship) { }
    
    public override void Update() {
        if(switchState())
            return;

        float r = Random.Range(-90, 90);
        mShip.RotateTowards(rotateVector(Vector2.up, r));
        mShip.Trust();
    }

    private bool switchState() {
        PlayerControls player = GameObject.FindObjectOfType<PlayerControls>();
        if(player == null)
            return false;

        Vector3 direction = player.transform.position - GameObject.transform.position;
        float angle = Vector3.Angle(direction, GameObject.transform.up);
        if(viewDistance <= direction.magnitude && angle <= viewRadius) {
            mStateMachine.SetState(NextState);
            return true;
        }

        return false;
    }

    private Vector2 rotateVector(Vector2 vector, float deg) {
        Vector2 result;
        float rad = deg * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);

        result.x = (vector.x * cos) - (vector.y * sin);
        result.y = (vector.x * sin) + (vector.y * cos);

        return result;
    }
}
