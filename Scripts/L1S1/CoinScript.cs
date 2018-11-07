using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	private LevelManager_L1S1 gameLevelManager;
	public int coinValue;

	// Use this for initialization
	void Start () {
		gameLevelManager = FindObjectOfType<LevelManager_L1S1> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
	        if (other.tag == "Player1") {
			gameLevelManager.AddCoins (coinValue);
			Destroy (gameObject);
		}
	}
}
