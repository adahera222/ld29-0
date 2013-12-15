// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class TriggeredGravityScript : MonoBehaviour {

    private float _gravityScale;

	void Start () {
        // preserve the initial gravity scale value.
        // temporarily set to zero.
        _gravityScale = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = 0f;
	}
	
    void Activate(GameObject obj) {
        // activate the gravity.
        rigidbody2D.gravityScale = _gravityScale;
	}
}
