using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript_L1S2 : MonoBehaviour {

	private LevelManager_L1S2 gameLevelManager;
	public int coinValue;

	void Start () {
		gameLevelManager = FindObjectOfType<LevelManager_L1S2> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player1") {
			gameLevelManager.AddCoins (coinValue);
			Destroy (gameObject);
		}
	}
}




