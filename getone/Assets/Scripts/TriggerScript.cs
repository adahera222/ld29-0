// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

    public Transform target = null;
    public bool multiple = false;

    private bool _triggered = false;

	void Start () {
	}

    void TriggerObject(GameObject obj) {
        if (!multiple && _triggered) return;
        _triggered = true;
        if (target != null) {
            target.gameObject.SendMessage("Activate", obj,
                                          SendMessageOptions.DontRequireReceiver);
        } else {
            gameObject.SendMessage("Activate", obj,
                                   SendMessageOptions.DontRequireReceiver);
        }
        if (audio != null && audio.clip != null) {
            audio.Play();
        }
    }
	
    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            TriggerObject(coll.gameObject);
            break;
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            TriggerObject(coll.gameObject);
            break;
        }
    }
}
