// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class TriggeredGravityScript : MonoBehaviour {

    public Transform trigger = null;

    private float _gravityScale;

	void Start () {
        // Detect the change of the connected trigger.
        if (trigger != null) {
            TriggerScript script = trigger.gameObject.GetComponent<TriggerScript>();
            if (script != null) {
                script.activated += OnTriggerActivated;
            }
            // preserve the initial gravity scale value.
            // temporarily set to zero.
            _gravityScale = rigidbody2D.gravityScale;
            rigidbody2D.gravityScale = 0f;
        }
	}
	
    void OnTriggerActivated(object sender, System.EventArgs args) {
        // activate the gravity.
        rigidbody2D.gravityScale = _gravityScale;
	}
}
