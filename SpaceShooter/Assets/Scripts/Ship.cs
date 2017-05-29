using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class Ship : MonoBehaviour {
    private float mSpeedMax;
    private float mTurnAngleMax;

    private Rigidbody mRigidbody;

    private float mSpeed;
    
    void Start() {
        mRigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        mRigidbody.velocity = transform.up * mRigidbody.velocity.magnitude;
        controls();
    }

    public void SetValues(Ship.SValues values) {
        mSpeedMax = values.speedMax;
        mSpeed = mSpeedMax; // Do in state
        mTurnAngleMax = values.turningAngleMax;
    }

    public void RotateLeft() {
        rotate(1);
    }

    public void RotateRight() {
        rotate(-1);
    }

    private void rotate(int sign) {
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.z += sign * mTurnAngleMax * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
    }

    public void RotateTowards(Vector3 position) {
        float angle = Mathf.Clamp(Vector3.Angle(transform.forward, position), 0, mTurnAngleMax);
        float sign = Mathf.Sign(Vector3.Cross(position, transform.forward).z);
        Vector3 rotation = Vector3.forward * angle * sign * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
    }

    void controls() {
        Vector3 rotation = transform.rotation.eulerAngles;

        if(Input.GetKey(KeyCode.A))
            RotateLeft();
        else if(Input.GetKey(KeyCode.D))
            RotateRight();

        if(Input.GetKey(KeyCode.W))
            mRigidbody.velocity = transform.up * mSpeed * Time.deltaTime;
    }

    [Serializable]
    public struct SValues {
        public float speedMax;
        public float turningAngleMax;
    }
}
