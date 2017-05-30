using UnityEngine;

[RequireComponent(typeof(Ship))]
public class PatrolState : AState {

	public PatrolState (IStateMachine stateMachine, Ship ship) : base(stateMachine, ship) {
	}
    
    public override void Update() {
        float r = Random.Range(-90, 90);
        mShip.RotateTowards(rotateVector(Vector2.up, r));
        mShip.Trust();
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
