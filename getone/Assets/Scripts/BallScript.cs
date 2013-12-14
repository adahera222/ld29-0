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
