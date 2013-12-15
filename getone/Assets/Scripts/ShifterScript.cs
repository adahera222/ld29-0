// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class ShifterScript : MonoBehaviour {

	void Start () {
	}

    void OnTriggerEnter2D(Collider2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            {
                // Change the ball direction.
                Transform ball = coll.gameObject.GetComponent<Transform>();
                BallScript script = ball.gameObject.GetComponent<BallScript>();
                if (script.SetDirection(-transform.localScale.x)) {
                    audio.Play();
                }
            }
            break;
        }
    }            
}
