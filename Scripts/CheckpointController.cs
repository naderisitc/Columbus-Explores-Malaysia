using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

	public Sprite redFlag;
	public Sprite greenFlag;
	private SpriteRenderer checkpointSpriteRenderer;
	public bool checkpointReached;
	public AudioClip MusicClip;
	public AudioSource MusicSource;

	void Start () {
		checkpointSpriteRenderer = GetComponent<SpriteRenderer> ();
		MusicSource.clip = MusicClip;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player1") {
			checkpointSpriteRenderer.sprite = greenFlag;
			checkpointReached = true;
			MusicSource.Play ();
		}
	}
}
