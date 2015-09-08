using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class ReactionFromPanelScript : MonoBehaviour {
	public GameObject winPanel;

	void Start() {
		Time.timeScale = 1; // spustenie hry
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			Time.timeScale = 0; // pauznutie hry

			winPanel.SetActive(true);
			GameObject btnInteractable = GameObject.Find("NextLvlBtn");
			print (btnInteractable);
			btnInteractable.GetComponent<Button>().interactable = false;
		}
	}

	public void NextLevel() {
		print ("nextLevel");
	}
	
	public void Restart() {
		print ("restartLevel");
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void BackToLevelSelector() {
		print ("backLevelSelector");
		Application.LoadLevel ("LevelSelectorScene");
	}

	public void BackToGame() {
		print ("backToGame");
		Time.timeScale = 1; // spustenie hry
		winPanel.SetActive(false);
	}
}
