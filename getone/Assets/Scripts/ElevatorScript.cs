// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour {

    // Path attached to this carrier.
    public Transform path = null;
    // Speed of transportation. 
    public float movingSpeed = 1.0f;
    
    private bool _moving = false;
    private float _t0;          // start time.
    private Vector3 _base;       // initial position.

	void Start () {
        // Save the initial position.
        _base = transform.position;
	}
	
	void Update () {
        if (_moving) {
            // Oscillating: y = sin(t)
            float dt = (Time.time - _t0);
            float y = Mathf.Sin(movingSpeed * dt);
            Vector3 v = new Vector3(0f, y*y, 0f);
            v = path.localToWorldMatrix.MultiplyVector(v);
            transform.position = _base + v;
        }
	}

    void Activate(GameObject obj) {
        // Activate the motion.
        if (!_moving) {
            _moving = true;
            _t0 = Time.time;
        }
    }
}
