using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TrustEngine : AEngine {
    private Rigidbody mRigidbody;
    private Ship mShip;
    private AEngine mEngine;

    void Start() {
        mRigidbody = GetComponent<Rigidbody>();
        mShip = GetComponent<Ship>();
        mEngine = GetComponent<AEngine>();
    }

    void Update() {
        mRigidbody.velocity = transform.up * mRigidbody.velocity.magnitude;
    }
    
    public override void Move() {
        mRigidbody.velocity = transform.up * mEngine.Power / mShip.Mass * Time.deltaTime;
    }
}
