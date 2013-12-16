// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class TriggeredPhysicsScript : MonoBehaviour {

    public float delay = 0f;

	void Start () {
        rigidbody2D.isKinematic = true;
	}
	
    void Activate(GameObject obj) {
        Invoke("Doit", delay);
    }

    void Doit() {
        rigidbody2D.isKinematic = false;
	}
}
