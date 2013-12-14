// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public Transform arrow = null;
    public Transform ball = null;
    public float acceleration = 40f;

    private bool _pressed = false;

	void Start () {
	}

    void Update() {
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
            GameObject obj = ball.gameObject;
            BallScript script = obj.GetComponent<BallScript>();
            obj.rigidbody2D.AddForce(acceleration * arrow.right);
            if (!_pressed) {
                _pressed = true;
                audio.Play();
            }
        } else {
            _pressed = false;
        }
	}

    public void Shift(Transform shifter) {
        // Shifter activated.
        arrow.rotation = shifter.rotation;
    }
}
