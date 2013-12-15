// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class RangeMotionScript : MonoBehaviour {

    // moveSpeed: 
    public float moveSpeed = 1.0f;
    public Vector2 moveRange = Vector2.right;
    
    private float _t0;
    private Vector3 _base;

	void Start () {
        _t0 = Time.time;
        _base = transform.position;
    }
	
	void Update () {
        float d = moveSpeed * (Time.time-_t0);
        float dx = triangle(d)*moveRange.x;
        float dy = triangle(d)*moveRange.y;
        transform.position = new Vector3(_base.x+dx, _base.y+dy, _base.z);
	}

    float triangle(float t) {
        return Mathf.PingPong(t+1.0f, 2.0f)-1.0f;
	}
}
