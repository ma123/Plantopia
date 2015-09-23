using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {
	private int openedLevel = 1;	
	private int numberOfLevels = 9;
	public GameObject levelLoadingPanel;
	public Image progressBarImage;
	private GameObject levelObject;
	private int loadProgress;

	void Start() {
		levelLoadingPanel.SetActive (false);
		//progressText.SetActive (false);
		//progressBarImage.SetActive (false);
		openedLevel = PlayerPrefs.GetInt ("openedLevel", 1);

		// vypnutie interakcie levelov ktore nie su pristupne
		for(int i = openedLevel+1; i <= numberOfLevels; i++) {
			levelObject = GameObject.Find("Lvl"+i+"Btn");
			levelObject.GetComponent<Button>().interactable = false;
		}
	}

	public void OnClickedLevel(int currentLevel) {
		PlayerPrefs.SetInt("currentLevel", currentLevel);
		string s = "Lvl" + currentLevel;
		StartCoroutine (DisplayLevelLoadingScreen(s));
	}

	IEnumerator DisplayLevelLoadingScreen(string level) {
		levelLoadingPanel.SetActive (true);

		AsyncOperation async = Application.LoadLevelAsync (level);
		while(!async.isDone) {
			loadProgress = (int)(async.progress * 100);
			print (loadProgress);
			yield return null;
		}
	}
}
