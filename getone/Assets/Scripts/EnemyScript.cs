// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    // moveSpeed: 
    public float moveSpeed = 1.0f;
    // moveRange: randomly wiggle within this area (h & v).
    public float moveRange = 1.0f;
    
    private Rect bounds;
    private Vector2 direction;

	void Start () {
        initDirection();
        bounds = new Rect(transform.position.x-moveRange, 
                          transform.position.y-moveRange,
                          moveRange*2, moveRange*2);
    }
	
	void Update () {
        transform.Translate(direction);
        if (!bounds.Contains(transform.position)) {
            initDirection();
        }
        float x = Mathf.Clamp(transform.position.x, bounds.xMin, bounds.xMax);
        float y = Mathf.Clamp(transform.position.y, bounds.yMin, bounds.yMax);
        transform.position = new Vector3(x, y, transform.position.z);
	}

    void OnCollisionEnter2D(Collision2D coll) {
        initDirection();
    }

    // initDirection: randomize a direction.
    void initDirection() {
        float x = Random.Range(-1f, +1f);
        float y = Random.Range(-1f, +1f);
        direction = (new Vector2(x, y))*moveSpeed;
	}
}
