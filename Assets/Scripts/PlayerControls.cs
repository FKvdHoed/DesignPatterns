using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Ship))]
public class PlayerControls : MonoBehaviour {
    private Ship mShip;
    
	void Start () {
        mShip = GetComponent<Ship>();
	}
	
	void Update () {
        if(Input.GetKey(KeyCode.A))
            mShip.RotateLeft();
        else if(Input.GetKey(KeyCode.D))
            mShip.RotateRight();

        if(Input.GetKey(KeyCode.W))
            mShip.Trust();
    }
}
