using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TrustEngine : AEngine {
    private Rigidbody mRigidbody;
    private Ship mShip;

    void Start() {
        mRigidbody = GetComponent<Rigidbody>();
        mShip = GetComponent<Ship>();
    }

    void Update() {
        mRigidbody.velocity = transform.up * mRigidbody.velocity.magnitude;
    }
    
    public override void Move() {
        mRigidbody.velocity = transform.up * Power / mShip.Mass * Time.deltaTime;
    }
}
