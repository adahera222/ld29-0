// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class TrapDoorScript : MonoBehaviour {

    public event System.EventHandler activated;

    private bool _on = false;

	void Start () {
	}
	
    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            if (!_on) {
                _on = true;
                if (activated != null) {
                    activated(this, new System.EventArgs());
                }
                audio.Play();
            }
            break;
        }
    }
}
