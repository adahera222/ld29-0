// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class MovingFloorScript : MonoBehaviour {

    public Transform trigger = null;
    
    public float movingSpeed = 1.0f;
    public float movingRange = 1.0f;

    private bool _moving = false;
    private float _t0;          // start time.
    private Vector3 _pos;       // initial position.

	void Start () {
        // Detect the change of the connected trigger.
        if (trigger != null) {
            TriggerScript script = trigger.gameObject.GetComponent<TriggerScript>();
            if (script != null) {
                script.activated += OnTriggerActivated;
            }
        }
        // Save the initial position.
        _pos = transform.position;
	}
	
	void Update () {
        if (_moving) {
            // Oscillating: y = sin(t)
            float dt = (Time.time - _t0);
            float y = movingRange * Mathf.Sin(movingSpeed * dt);
            transform.position = _pos + Vector3.up * y;
        }
	}

    void OnTriggerActivated(object sender, System.EventArgs args) {
        // Start oscillating.
        _moving = true;
        _t0 = Time.time;
	}
}
