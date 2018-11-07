using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {
	public float respawnDelay;
	public Vector3 respawnPoint;
	public LevelManager_Level3 gameManagerCar;

	void Start () {
		respawnPoint = transform.position;
		gameManagerCar = FindObjectOfType<LevelManager_Level3> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player1") {
			gameManagerCar.RespawnWeight ();
			gameManagerCar.RespawnSaw ();
		}
		}
}
