using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Transform mFollow;

    void Start() {
        mFollow = GameObject.FindObjectOfType<EnemyAI>().transform;
    }
    
	void Update () {
        transform.position = new Vector3(mFollow.position.x, mFollow.position.y, transform.position.z);
	}
}
