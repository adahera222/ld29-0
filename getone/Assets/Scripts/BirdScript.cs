// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {

    // Path attached to this carrier.
    public Transform path = null;
    // Speed of transportation. 
    public float movingSpeed = 1.0f;

    private Transform _victim = null;
    private float _t0;          // start time.
    private Vector3 _pos0;
    private Vector3 _pos1;
    private Vector3 _pos2;
    private Vector3 _pos3;
    private Vector3 _base;      // base position.
    private Vector3 _delta;     // diff to the victim.

	void Start () {
        // Set the base position.
        _pos0 = path.localToWorldMatrix.MultiplyVector(new Vector3(-1f, -1f, 0f));
        _pos1 = path.localToWorldMatrix.MultiplyVector(new Vector3(-1f, +1f, 0f));
        _pos2 = path.localToWorldMatrix.MultiplyVector(new Vector3(+1f, +1f, 0f));
        _pos3 = path.localToWorldMatrix.MultiplyVector(new Vector3(+1f, -1f, 0f));
        _base = transform.position - _pos0;
	}
	
	void Update () {
        if (_victim != null) {
            float d = (Time.time - _t0) * movingSpeed;
            float d0 = (_pos1-_pos0).magnitude;
            float d1 = (_pos2-_pos1).magnitude;
            float d2 = (_pos3-_pos2).magnitude;
            Vector3 v = Vector3.zero;
            if (0 <= d && d < d0) {
                v = new Vector3(-1f, -1f+d/d0*2f, 0f);
            } else if (d0 <= d && d < d0+d1) {
                v = new Vector3(-1f+(d-d0)/d1*2f, +1f, 0f);
            } else if (d0+d1 <= d && d < d0+d1+d2) {
                v = new Vector3(+1f, +1f-(d-d0-d1)/d2*2f);
            }
            if (v != Vector3.zero) {
                v = path.localToWorldMatrix.MultiplyVector(v);
                transform.position = _base + v;
                _victim.position = _delta + transform.position;
                _victim.rigidbody2D.velocity = Vector2.zero;
            }
        }
	}

    void Activate(GameObject obj) {
        // Activate the motion.
        if (_victim == null) {
            _victim = obj.GetComponent<Transform>();
            _delta = _victim.position - transform.position;
            _t0 = Time.time;
        }
    }
}
