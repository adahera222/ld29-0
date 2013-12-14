// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {

    // Path attached to this carrier.
    public Transform path = null;
    // 
    public float movingDuration = 10.0f;

    private Transform _victim = null;
    private float _t0;          // start time.
    private Vector3 _base;      // base position.
    private Vector3 _delta;     // diff to the victim.

	void Start () {
        // Set the base position.
        Vector3 v = new Vector3(-1f, -1f, 0f);
        v = path.localToWorldMatrix.MultiplyVector(v);
        _base = transform.position - v;
	}
	
	void FixedUpdate () {
        if (_victim != null) {
            // Move along (-1,0,0) to (+1,0,0) of the attached object.
            float dt = (Time.time - _t0) / movingDuration;
            print("dt="+dt);
            Vector3 v = Vector3.zero;
            if (0 <= dt && dt < 1) {
                v = new Vector3(-1f, -1f+dt*2f, 0f);
            } else if (1 <= dt && dt < 2) {
                v = new Vector3(-1f+(dt-1)*2f, +1f, 0f);
            } else if (2 <= dt && dt < 3) {
                v = new Vector3(+1f, +1f-(dt-2)*2f);
            } 
            if (v != Vector3.zero) {
                v = path.localToWorldMatrix.MultiplyVector(v);
                transform.position = _base + v;
                _victim.position = _delta + transform.position;
                print("viction="+_victim.position);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            // Activate the motion.
            if (_victim == null) {
                _victim = coll.gameObject.GetComponent<Transform>();
                _delta = _victim.position - transform.position;
                _t0 = Time.time;
            }
            break;
        }
    }
}
