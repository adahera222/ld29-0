// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public Transform arrow = null;
    public float acceleration = 400f;

	void Start () {
	}

    bool canJump {
        get { return true; }
    }

    void Update() {
        arrow.position = transform.position;
    }

	void FixedUpdate () {
        bool button = (Input.GetButtonDown("Horizontal") ||
                       Input.GetButtonDown("Vertical") ||
                       Input.GetButtonDown("Fire1") ||
                       Input.GetButtonDown("Jump"));
        if (button) {
            if (canJump) {
                rigidbody2D.AddForce(acceleration * arrow.right);
                audio.Play();
            }
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
        case "Floor":
            audio.Play();
            break;
        case "Enemy":
            GlobalScript.Instance.GameOver();
            break;
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        switch (coll.gameObject.tag) {
        case "SafeZone":
            GlobalScript.Instance.GameOver();
            break;
        }
    }
}
