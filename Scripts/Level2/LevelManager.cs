using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float respawnDelay;
	public L2S1_PlayerC gamePlayer;
	public int coins2;
	public Text coinText;
	public int pLife;
	public GameObject gameOver;
	public GameObject[] playerHearts;
	public GameObject player;

	void Start () {
		gamePlayer = FindObjectOfType<L2S1_PlayerC> ();
		coinText.text = "Coins: " + coins2;
		}

	void Update () {
		if (pLife <= 0) {
			player.SetActive (false);
			gameOver.SetActive (true);
		}
	}
	public void HurtP() {
		pLife -= 1;

		for (int i = 0; i < playerHearts.Length; i++) {

			if (pLife > i) {
				playerHearts [i].SetActive (true);
			}
			else { 
				playerHearts[i].SetActive(false);
			}
		}
	}

	public void Respawn(){
		StartCoroutine ("RespawnCoroutine");
	}

	public IEnumerator RespawnCoroutine() {
		gamePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (respawnDelay);
		gamePlayer.transform.position = gamePlayer.respawnPoint;
		gamePlayer.gameObject.SetActive (true);
	}

	public void AddCoins(int numberOfCoins){
		coins2 += numberOfCoins;
		coinText.text = "Coins: " + coins2;
	}
}
