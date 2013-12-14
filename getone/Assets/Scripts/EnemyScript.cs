// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public float moveRange = 1.0f;
    
    private Rect bounds;
    private Vector2 direction;

	// Use this for initialization
	void Start () {
        initDirection();
        bounds = new Rect(transform.position.x-moveRange, 
                          transform.position.y-moveRange,
                          moveRange*2, moveRange*2);
    }
	
	// Update is called once per frame
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

    void initDirection() {
        float x = Random.Range(-1f, +1f);
        float y = Random.Range(-1f, +1f);
        direction = (new Vector2(x, y))*moveSpeed;
	}
}
