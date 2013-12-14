using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
            Vector2 d = new Vector2(100, 400);
            rigidbody2D.AddForce(d);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
