// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float acceleration = 40f;

    private Transform _ball = null;
    private float _dt = 0;

	void Start () {
        _ball = transform.GetChild(0);
	}

	void FixedUpdate () {
        if (GlobalScript.Instance.GetButton()) {
            // Jump/Accelerate.
            BallScript script = _ball.gameObject.GetComponent<BallScript>();
            script.Accel(_dt * acceleration * transform.right * _ball.transform.localScale.x);
            _dt += Time.deltaTime;
        } else {
            _dt = 0;
        }
	}
}
