// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour {

    public Transform trigger = null;
    public Transform path = null;
    // Speed of transportation. 
    public float movingSpeed = 1.0f;
    
    private bool _moving = false;
    private float _t0;          // start time.
    private Vector3 _base;       // initial position.

	void Start () {
        // Detect the change of the connected trigger.
        if (trigger != null) {
            TriggerScript script = trigger.gameObject.GetComponent<TriggerScript>();
            if (script != null) {
                script.activated += OnTriggerActivated;
            }
        }
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

    void OnTriggerActivated(object sender, System.EventArgs args) {
        // Start oscillating.
        _moving = true;
        _t0 = Time.time;
	}
}
