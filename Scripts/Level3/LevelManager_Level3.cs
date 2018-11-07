using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class LevelManager_Level3 : MonoBehaviour {

	public float respawnDelay;
	public L3_PlayerC gamePlayer;
	public  int coins3;
	public Text coinText;
	private CarScript car;
	private SawScript saw;
	private WeigihtScript weight;
	public int pLife;
	public GameObject gameOver;
	public GameObject[] playerHearts;
	public GameObject player;

	void Start () {
		gamePlayer = FindObjectOfType<L3_PlayerC> ();
		car = FindObjectOfType<CarScript> ();
		saw = FindObjectOfType<SawScript> ();
		weight = FindObjectOfType<WeigihtScript> ();
		coinText.text = "Coins: " + coins3;
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

	public void RespawnCar(){
		StartCoroutine ("RespawnCarCoroutine");
	}

	public IEnumerator RespawnCarCoroutine() {
		car.gameObject.SetActive (false);
		yield return new WaitForSeconds (respawnDelay);
		car.transform.position = car.respawnPoint;
		car.gameObject.SetActive (true);
	}

	public void RespawnSaw(){
		StartCoroutine ("RespawnSawCoroutine");
	}

	public IEnumerator RespawnSawCoroutine() {
		saw.gameObject.SetActive (false);
		yield return new WaitForSeconds (respawnDelay);
		saw.transform.position = saw.respawnPoint;
		saw.gameObject.SetActive (true);
	}

	public void RespawnWeight(){
		StartCoroutine ("RespawnWeightCoroutine");
	}

	public IEnumerator RespawnWeightCoroutine() {
		weight.gameObject.SetActive (false);
		yield return new WaitForSeconds (respawnDelay);
		weight.transform.position = weight.respawnPoint;
		weight.gameObject.SetActive (true);
	}

	public void AddCoins(int numberOfCoins){
		coins3 += numberOfCoins;
		coinText.text = "Coins: " + coins3;
	}
}




