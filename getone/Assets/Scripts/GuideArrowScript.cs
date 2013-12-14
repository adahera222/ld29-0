// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class GuideArrowScript : MonoBehaviour {

    private Transform goal;

	void Start () {
        GameObject obj = GameObject.FindWithTag("Goal");
        goal = obj.transform;
	}
	
	void Update () {
        // Direct the goal.
        Vector2 pos0 = new Vector3(transform.position.x, transform.position.y, 0);
        Vector2 pos1 = new Vector3(goal.position.x, goal.position.y, 0);
        float angle = Vector2.Angle(Vector2.right, pos1-pos0);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
