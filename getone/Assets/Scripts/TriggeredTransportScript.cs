// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class TriggeredTransportScript : MonoBehaviour {

    // Speed of transportation. 
    public float moveSpeed = 1.0f;
    public Vector2 moveRange = Vector2.right;
    public bool oneTime = false;

    private bool _activated = false;
    private bool _moving = false;
    private float _t0;          // start time.
    private Vector3 _base;      // base position.

	void Start () {
        // Set the base position.
        _base = transform.position;
        if (rigidbody2D != null) {
            rigidbody2D.isKinematic = true;
        }
	}

	void Update () {
        if (_moving) {
            float d = moveSpeed * (Time.time-_t0);
            if (!oneTime || d < 1.0f) {
                float dx = triangle(d)*moveRange.x;
                float dy = triangle(d)*moveRange.y;
                transform.position = new Vector3(_base.x+dx, _base.y+dy, _base.z);
            } else {
                _moving = false;
                if (rigidbody2D != null) {
                    rigidbody2D.isKinematic = false;
                    rigidbody2D.velocity = moveRange * moveSpeed;
                }
            }
        }
	}

    float triangle(float t) {
        return Mathf.PingPong(t, 1.0f);
	}

    public void Activate(GameObject obj) {
        // Activate the motion.
        if (!_activated) {
            _activated = true;
            _moving = true;
            _t0 = Time.time;
        }
    }
}
