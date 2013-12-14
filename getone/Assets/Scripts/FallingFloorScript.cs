// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class FallingFloorScript : MonoBehaviour {

    public Transform trapdoor = null;

    private float _gravityScale;

	void Start () {
        if (trapdoor != null) {
            TrapDoorScript script = trapdoor.gameObject.GetComponent<TrapDoorScript>();
            if (script != null) {
                script.activated += OnTrapDoorActivated;
            }
        }

        _gravityScale = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = 0f;
	}
	
    void OnTrapDoorActivated(object sender, System.EventArgs args) {
        rigidbody2D.gravityScale = _gravityScale;
	}
}
