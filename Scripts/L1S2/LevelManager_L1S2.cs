using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager_L1S2 : MonoBehaviour {

	public float respawnDelay;
	public L1S2_PlayerC gamePlayer;
	public int coins11;
	public Text coinText;
	public int pLife;
	public GameObject gameOver;
	public GameObject[] playerHearts;
	public GameObject player;


	// Use this for initialization
	void Start () {
		gamePlayer = FindObjectOfType<L1S2_PlayerC> ();
		coinText.text = "Coins: " + coins11;
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
		coins11 += numberOfCoins;
		coinText.text = "Coins: " + coins11;
	}
}
