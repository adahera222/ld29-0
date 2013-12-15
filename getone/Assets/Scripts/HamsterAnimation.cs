using UnityEngine;
using System.Collections;

public class HamsterAnimation : MonoBehaviour {

	public Transform ball;
	public Animator anim;
	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ball.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal")*speed));
		anim.SetFloat("Speed", Input.GetAxis("Horizontal"));
	}
}
