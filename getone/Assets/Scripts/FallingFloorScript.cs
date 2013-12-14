// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class FallingFloorScript : MonoBehaviour {

    // trapdoor to be triggered.
    public Transform trapdoor = null;

    private float _gravityScale;

	void Start () {
        // Detect the change of the connected trapdoor.
        if (trapdoor != null) {
            TrapDoorScript script = trapdoor.gameObject.GetComponent<TrapDoorScript>();
            if (script != null) {
                script.activated += OnTrapDoorActivated;
            }
        }
        // preserve the initial gravity scale value.
        // temporarily set to zero.
        _gravityScale = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = 0f;
	}
	
    void OnTrapDoorActivated(object sender, System.EventArgs args) {
        // activate the gravity.
        rigidbody2D.gravityScale = _gravityScale;
	}
}
