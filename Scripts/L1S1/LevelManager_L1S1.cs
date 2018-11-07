using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager_L1S1 : MonoBehaviour {

	public float respawnDelay;
	public PlayerController gamePlayer;
	public int coins1;
	public Text coinText;
	public int pLife;
	public GameObject gameOver;
	public GameObject[] playerHearts;
	public GameObject player;

	// Use this for initialization
	void Start () {
		gamePlayer = FindObjectOfType<PlayerController> ();
		coinText.text = "Coins: " + coins1;
	}

	// Update is called once per frame
	void Update () {
		if (pLife <= 0) {
			player.SetActive (false);
			gameOver.SetActive(true);
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
		coins1 += numberOfCoins;
		coinText.text = "Coins: " + coins1;
	}
}







