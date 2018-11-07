using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	
	public void SkipStory() {
		SceneManager.LoadScene("1ForestLevel");
	}		

	public void PlayGame ()	{
		SceneManager.LoadScene("StoryLine");
	}

	public void QuitGame() {
		Application.Quit ();
	}
		
	public void MainMenu1()	{
		SceneManager.LoadScene ("Menu");
	}

	public void Restart_L1S1() {
		SceneManager.LoadScene ("Level1_Scene1");
	}

	public void Restart_L1S2() {
		SceneManager.LoadScene ("Scene2");
	}

	public void Restart_L2()  {
		SceneManager.LoadScene ("Level2Scene1");
	}

	public void Restart_L3() {
		SceneManager.LoadScene ("Level3");
	}

}
