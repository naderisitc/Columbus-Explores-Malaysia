using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricScript : MonoBehaviour {
	public AudioClip MusicClip;
	public AudioSource MusicSource;

	void Start () {
		MusicSource.clip = MusicClip;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player1") {
			MusicSource.Play ();
		}
}
}
