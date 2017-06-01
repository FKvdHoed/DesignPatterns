using UnityEngine;

public class Turret {}
public class BulletTurret : Turret { }
public class LazerTurret : Turret { }

[DisallowMultipleComponent]
public class Ship : MonoBehaviour {
    public float Stearing { get; set; }
    public float Mass { get; set; }
    public Turret[] Weaponbay { get; set; }

    private AEngine mEngine;
    private ASpecial mSpecial;

    void Start() {
        mEngine = GetComponent<AEngine>();
        mSpecial = GetComponent<ASpecial>();
    }

    public void RotateLeft() {
        rotate(1);
    }

    public void RotateRight() {
        rotate(-1);
    }

    private void rotate(int sign) {
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.z += sign * Stearing * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
    }

    public void RotateTowards(Vector3 position) {
        float angle = Mathf.Clamp(Vector3.Angle(transform.up, position), 0, Stearing);
        float sign = Mathf.Sign(Vector3.Cross(transform.up, position).z);
        Vector3 rotation = Vector3.forward * angle * sign * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotation);
    }

    public void Move() {
        mEngine.Move();
    }

    public void ActivateSpecial() {
        mSpecial.Activate();
    }
}
