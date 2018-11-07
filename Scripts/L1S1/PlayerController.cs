using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

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
	public LevelManager_L1S1 gameLevelManager;
	public AudioClip MusicClip;
	public AudioSource MusicSource;
	public AudioClip MusicClip2;
	public AudioSource MusicSource2;
	public GameObject gameOver;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		playerAnimation = GetComponent<Animator> ();
		respawnPoint = transform.position;
		gameLevelManager = FindObjectOfType<LevelManager_L1S1> ();
		MusicSource.clip = MusicClip;
		MusicSource2.clip = MusicClip2;
	}
	
	// Update is called once per frame
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
			MusicSource2.Play ();
			gameLevelManager.HurtP ();
		}

		if (other.tag == "Checkpoint") {
			respawnPoint = other.transform.position;
		}
			
		if (other.tag == "cactus") {
			gameLevelManager.Respawn ();
			MusicSource.Play ();
			gameLevelManager.HurtP ();
		}

		if (other.tag == "sign") {
			if (gameLevelManager.coins1 >= 8) {
				SceneManager.LoadScene ("2ChineseLevel");
			} else {
				gameOver.SetActive(true);			
			}
		}
	}
}
