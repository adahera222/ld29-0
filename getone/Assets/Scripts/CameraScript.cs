// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform focus = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (focus != null) {
            float z = transform.position.z;
            transform.position = new Vector3(focus.position.x, focus.position.y, z);
        }
	}
}
