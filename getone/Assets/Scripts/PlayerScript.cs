// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public Transform arrow = null;
    public Transform ball = null;
    public float acceleration = 400f;

	void Start () {
	}

    void Update() {
        // Adjust the arrow position.
        arrow.position = ball.position;
    }

	void FixedUpdate () {
        bool button = (Input.GetButtonDown("Horizontal") ||
                       Input.GetButtonDown("Vertical") ||
                       Input.GetButtonDown("Fire1") ||
                       Input.GetButtonDown("Jump"));
        if (button) {
            // Jump/Accelerate.
            GameObject obj = ball.gameObject;
            BallScript script = obj.GetComponent<BallScript>();
            if (script.canJump) {
                obj.rigidbody2D.AddForce(acceleration * arrow.right);
                audio.Play();
            }
        }
	}

    public void Shift(Transform shifter) {
        // Shifter activated.
        arrow.rotation = shifter.rotation;
    }
}
