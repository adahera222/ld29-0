// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public Transform arrow = null;
    public Transform ball = null;
    public float acceleration = 40f;

    private float _dt = 0;

	void Start () {
	}

	void Update () {
        // Adjust the arrow position.
        arrow.position = ball.position;
	}

	void FixedUpdate () {
        bool button = (Input.GetButton("Horizontal") ||
                       Input.GetButton("Vertical") ||
                       Input.GetButton("Fire1") ||
                       Input.GetButton("Jump"));
        if (button) {
            // Jump/Accelerate.
            BallScript script = ball.gameObject.GetComponent<BallScript>();
            script.Accel(_dt * acceleration * arrow.right);
            _dt += Time.deltaTime;
        } else {
            _dt = 0;
        }
	}

    public void Shift(Transform shifter) {
        // Shifter activated.
        arrow.rotation = shifter.rotation;
    }
}
