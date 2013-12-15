// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BouncerScript : MonoBehaviour {

    // Ratio of extra force.
    public float extraBounciness = 1.0f;

	void Start () {
	}

    void Activate(GameObject obj) {
        // Add extra force to the ball.
        Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
        body.AddForce(body.velocity * extraBounciness);
    }
}
