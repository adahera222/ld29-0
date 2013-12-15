// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class ParallaxBackgroundScript : MonoBehaviour {

    // scroll speed relative to the camera motion.
    public float parallaxRatio = 0.1f;

    private Transform _camera;
    private Vector3 _base;

	void Start () {
        // Find a Camera object automatically.
        GameObject obj = GameObject.FindWithTag("MainCamera");
        if (obj != null) {
            _camera = obj.transform;
            _base = _camera.position;
        }
	}
	
	void Update () {
        Vector3 d = (_base - _camera.position) * parallaxRatio;
        transform.localPosition = new Vector3(d.x, d.y, transform.localPosition.z);
	}
}
