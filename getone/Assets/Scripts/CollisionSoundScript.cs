// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class CollisionSoundScript : MonoBehaviour {

	void Start () {
	}

    void Ring() {
        if (audio != null) {
            audio.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            Ring();
            break;
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            Ring();
            break;
        }
    }
}
