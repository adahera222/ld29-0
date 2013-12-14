// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

    public Transform ball = null;
    public float acceleration = 400f;

    void Update() {
        transform.position = ball.position;
    }
	
	void FixedUpdate () {
        bool button = (Input.GetButtonDown("Horizontal") ||
                       Input.GetButtonDown("Vertical") ||
                       Input.GetButtonDown("Fire1") ||
                       Input.GetButtonDown("Jump"));
        if (button) {
            GameObject obj = ball.gameObject;
            BallScript script = obj.GetComponent<BallScript>();
            if (script.canJump) {
                Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
                body.AddForce(acceleration * transform.right);
                audio.Play();
            }
        }
	}

}
