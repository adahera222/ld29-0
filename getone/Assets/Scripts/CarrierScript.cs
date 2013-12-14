// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class CarrierScript : MonoBehaviour {

    // Rail attached to this carrier.
    public Transform rail = null;
    // Speed of transportation. 
    public float movingSpeed = 1.0f;

    private bool _moving = false;
    private float _t0;          // start time.
    private Vector3 _pos0;
    private Vector3 _pos1;
    private Vector3 _base;      // base position.

	void Start () {
        // Set the base position.
        _pos0 = rail.localToWorldMatrix.MultiplyVector(-Vector3.right);
        _pos1 = rail.localToWorldMatrix.MultiplyVector(Vector3.right);
        _base = transform.position - _pos0;
	}
	
	void Update () {
        if (_moving) {
            // Move along (-1,0,0) to (+1,0,0) of the attached object.
            float d = (Time.time - _t0) * movingSpeed;
            float w = (_pos1-_pos0).magnitude;
            float x = -1f+d/w*2f;
            if (-1f <= x && x < +1f) {
                Vector3 v = new Vector3(x, 0f, 0f);
                v = rail.localToWorldMatrix.MultiplyVector(v);
                transform.position = _base + v;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            // Activate the motion.
            if (!_moving) {
                _moving = true;
                _t0 = Time.time;
            }
            break;
        }
    }
}
