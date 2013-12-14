// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	void Start () {
	}

    public bool canJump {
        get { return true; }
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
