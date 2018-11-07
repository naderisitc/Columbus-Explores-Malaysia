using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeigihtScript : MonoBehaviour {

	public float respawnDelay;
	public Vector3 respawnPoint;
	public LevelManager_Level3 gameManagerWeight;
	// Use this for initialization
	void Start () {
		respawnPoint = transform.position;
		gameManagerWeight = FindObjectOfType<LevelManager_Level3> ();
	}

	// Update is called once per frame
	void Update () {

	}



	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player1") {
			gameManagerWeight.RespawnWeight ();
			gameManagerWeight.RespawnSaw ();
			gameManagerWeight.RespawnCar ();
		
		}
	}
}