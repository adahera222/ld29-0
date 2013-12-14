// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BouncerScript : MonoBehaviour {

    public float extraBounciness = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Ball") {
            Rigidbody2D body = coll.gameObject.GetComponent<Rigidbody2D>();
            body.AddForce(body.velocity * extraBounciness);
            audio.Play();
        }
    }
}
