using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L3_PlayerC : MonoBehaviour {

	public float speed = 5f;
	public float jumpSpeed = 8f;
	private float movement = 0f;
	private Rigidbody2D rigidBody;
	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	private bool isTouchingGround;
	private Animator playerAnimation;
	public Vector3 respawnPoint;
	public LevelManager_Level3 gameLevelManager;
	public AudioClip MusicClip;
	public AudioSource MusicSource;
	public AudioClip MusicClip2;
	public AudioSource MusicSource2;
	public AudioClip MusicClip3;
	public AudioSource MusicSource3;
	public AudioClip MusicClip4;
	public AudioSource MusicSource4;
	public AudioClip MusicClip5;
	public AudioSource MusicSource5;
	public AudioClip MusicClip6;
	public AudioSource MusicSource6;
	public GameObject gameOver;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		playerAnimation = GetComponent<Animator> ();
		respawnPoint = transform.position;
		gameLevelManager = FindObjectOfType<LevelManager_Level3> ();
		MusicSource.clip = MusicClip;
		MusicSource2.clip = MusicClip2;
		MusicSource3.clip = MusicClip3;
		MusicSource4.clip = MusicClip4;
		MusicSource5.clip = MusicClip5;
		MusicSource6.clip = MusicClip6;
	}
	void Update () {
		isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius,groundLayer);
		movement = Input.GetAxis("Horizontal");
		if (movement > 0f) {
			rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
			transform.localScale = new Vector2 (0.4453136f, 0.4453136f);
		} else if (movement < 0f) {
			rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
			transform.localScale = new Vector2 (-0.4453136f, 0.4453136f);
		} else {
			rigidBody.velocity = new Vector2 (0, rigidBody.velocity.y);
		}

		if (Input.GetButtonDown ("Jump") && isTouchingGround) {
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, jumpSpeed);
		}

		playerAnimation.SetFloat ("Speed", Mathf.Abs(rigidBody.velocity.x));
		playerAnimation.SetBool ("OnGround", isTouchingGround);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "FallDetector") {
			gameLevelManager.Respawn ();
			MusicSource5.Play ();
			gameLevelManager.HurtP ();
		}

		if (other.tag == "Checkpoint") {
			respawnPoint = other.transform.position;
		}

		if (other.tag == "bomb") {
			gameLevelManager.Respawn ();
			MusicSource4.Play ();
			gameLevelManager.HurtP ();
		}
			
		if (other.tag == "spike" ) {
			gameLevelManager.Respawn ();
			MusicSource3.Play ();
			gameLevelManager.HurtP ();
		}

		if (other.tag == "saw" ) {
			gameLevelManager.Respawn ();
			MusicSource3.Play ();
			gameLevelManager.HurtP ();
		}

		if (other.tag == "barrel") {
			gameLevelManager.Respawn ();
			MusicSource4.Play ();
			gameLevelManager.HurtP ();
		}

		if (other.tag == "fire") {
			gameLevelManager.Respawn ();
			MusicSource5.Play ();
			gameLevelManager.HurtP ();
		}
			
		if (other.tag == "electric") {
			gameLevelManager.Respawn ();
			MusicSource6.Play ();
			gameLevelManager.HurtP ();
		}
			
		if (other.tag == "sign3") {
			if (gameLevelManager.coins3 >= 14) {
				SceneManager.LoadScene ("LastScene");
			} else {

				gameOver.SetActive(true);			}
		}
	}
		
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "car"){
			gameLevelManager.Respawn ();
		    MusicSource3.Play ();
			gameLevelManager.HurtP ();
	}

		if (coll.gameObject.tag == "zombie") {
			gameLevelManager.Respawn ();
			MusicSource.Play ();
			gameLevelManager.HurtP ();
		}

		if (coll.gameObject.tag == "saw") {
			gameLevelManager.Respawn ();
			MusicSource3.Play ();
			gameLevelManager.HurtP ();
		}

		if (coll.gameObject.tag == "weight") {
			gameLevelManager.Respawn ();
			MusicSource3.Play ();
			gameLevelManager.HurtP ();
		}

		if (coll.gameObject.tag == "fire") {
			gameLevelManager.Respawn ();
			MusicSource5.Play ();
			gameLevelManager.HurtP ();
		}
}
}



