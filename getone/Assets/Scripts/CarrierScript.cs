// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class CarrierScript : MonoBehaviour {

    // Rail attached to this carrier.
    public Transform rail = null;
    // Total duration of transportation. small -> fast.
    public float movingDuration = 1.0f;

    private bool _moving = false;
    private float _t0;          // start time.
    private Vector3 _base;      // base position.

	void Start () {
        // Set the base position.
        Vector3 v = new Vector3(-1f, 0f, 0f);
        v = rail.localToWorldMatrix.MultiplyVector(v);
        _base = transform.position - v;
	}
	
	void Update () {
        if (_moving) {
            // Move along (-1,0,0) to (+1,0,0) of the attached object.
            float dt = Time.time - _t0;
            if (0 <= dt && dt < movingDuration) {
                float x = dt/movingDuration;
                Vector3 v = new Vector3(-1f+x*2f, 0f, 0f);
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
