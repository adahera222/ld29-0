// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BouncerScript : MonoBehaviour {

    // Ratio of extra force.
    public float extraBounciness = 1.0f;

	void Start () {
	}

    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            // Add extra force to the ball.
            Rigidbody2D body = coll.gameObject.GetComponent<Rigidbody2D>();
            body.AddForce(body.velocity * extraBounciness);
            audio.Play();
            break;
        }
    }
}
