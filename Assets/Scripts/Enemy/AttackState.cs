using UnityEngine;

public class AttackState : AState {
    private static int sHPMin = 10;
    private static float sDistanceMax = 100;

    public AttackState(Ship ship) : base(ship) {
    }

    public override void Handle(IStateContext context) {
        if(switchState(context))
            return;

        PlayerControls player = GameObject.FindObjectOfType<PlayerControls>();
        if(player == null)
            return;
        
        Vector3 direction = GameObject.transform.position - player.transform.position;
        mShip.RotateTowards(direction);
        mShip.Move();

        //mShip.Shoot();
    }

    private bool switchState(IStateContext context) {
        if(false/*mShip.Health <= sHPMin*/) {
            context.SetState(new FleeState(mShip));
            return true;
        }
        else {
            PlayerControls player = GameObject.FindObjectOfType<PlayerControls>();
            if(player == null)
                return false;

            if(sDistanceMax <= (GameObject.transform.position - player.transform.position).magnitude) {
                context.SetState(new FleeState(mShip));
                return true;
            }
        }

        return false;
    }
}
