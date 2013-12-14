// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public Vector2 acceleration = new Vector2(100, 0);

	void Start () {
	}
	
	void FixedUpdate () {
        bool button = (Input.GetButton("Horizontal") ||
                       Input.GetButton("Vertical") ||
                       Input.GetButton("Fire1") ||
                       Input.GetButton("Jump"));
        if (button) {
            rigidbody2D.AddForce(acceleration);
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Floor") {
            audio.Play();
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "SafeZone") {
            GlobalScript.Instance.GameOver();
        }
    }
}
