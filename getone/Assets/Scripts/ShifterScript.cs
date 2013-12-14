// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class ShifterScript : MonoBehaviour {

	void Start () {
	}
	
    void OnTriggerEnter2D(Collider2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            // Change the ball direction.
            Transform player = coll.gameObject.GetComponent<Transform>().parent;
            PlayerScript script = player.gameObject.GetComponent<PlayerScript>();
            script.Shift(transform);
            audio.Play();
            break;
        }
    }
}
