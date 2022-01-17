using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public GameObject MenuPause;
	
	public void OnPlay()
    {
        SceneManager.LoadScene("Main");
    }
	
	public void PauseControl(){
		if (Time.timeScale == 1) {
			MenuPause.SetActive (true);
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
			MenuPause.SetActive (false);
		}
	}
	
	public void Restart () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}
	
	public void MenuUtama(){
		SceneManager.LoadScene("MenuUtama");
	}

}
