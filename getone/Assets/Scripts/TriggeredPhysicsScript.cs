// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class TriggeredPhysicsScript : MonoBehaviour {

	void Start () {
        rigidbody2D.isKinematic = true;
	}
	
    void Activate(GameObject obj) {
        rigidbody2D.isKinematic = false;
	}
}
