﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator myAnimator;
	public float bunnyJumpForce = 400f;
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Jump")) {
			if (myRigidBody.gravityScale < 0) {
				myRigidBody.AddForce (-transform.up * bunnyJumpForce);
			}
			if (myRigidBody.gravityScale > 0) {
				myRigidBody.AddForce (transform.up * bunnyJumpForce);
			}
		}
		if (transform.position.y > 0) {
			myRigidBody.gravityScale = -3;
		} else {
			myRigidBody.gravityScale = 3;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
