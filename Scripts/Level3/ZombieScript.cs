using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour {

	public float speed = 3f;
	private float movement = 2f;
	private Rigidbody2D rigidBody;
	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	private bool isTouchingGround;

	private Animator myAnimation;
	void Start () {
		
		rigidBody = GetComponent<Rigidbody2D> ();
		myAnimation = GetComponent<Animator> ();
	}
	
	void Update () {
		isTouchingGround = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, groundLayer);
		movement = Input.GetAxis ("Horizontal");
		if (movement > 0f) {
			rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
			transform.localScale = new Vector2 (0.463635f, 0.463635f);
		} else {
			rigidBody.velocity = new Vector2 (0, rigidBody.velocity.y);
		}

		myAnimation.SetFloat ("Speed", Mathf.Abs(rigidBody.velocity.x));
		myAnimation.SetBool ("OnGround", isTouchingGround);
	}
}
