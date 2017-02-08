using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	public int speed;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	void FixedUpdate () {
		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveX, moveY, 0.0f);

		rb.AddForce (movement * speed);
	}
}
