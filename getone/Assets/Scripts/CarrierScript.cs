// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class CarrierScript : MonoBehaviour {

    public Transform rail = null;
    public float movingDuration = 1.0f;

    private bool _moving = false;
    private float _t0;
    private Vector3 _base;

	void Start () {
        Vector3 v = new Vector3(-1f, 0f, 0f);
        v = rail.localToWorldMatrix.MultiplyVector(v);
        _base = transform.position - v;
	}
	
	void Update () {
        if (_moving) {
            float dt = Time.time - _t0;
            print("dt="+dt);
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
            // activate the motion.
            if (!_moving) {
                _moving = true;
                _t0 = Time.time;
            }
            break;
        }
    }
}
