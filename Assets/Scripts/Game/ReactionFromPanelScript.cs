using UnityEngine;
using System.Collections;

public class ReactionFromPanelScript : MonoBehaviour {
	public void NextLevel() {
		print ("nextLevel");
	}
	
	public void Restart() {
		print ("restartLevel");
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void Back() {
		print ("backLevelSelector");
		Application.LoadLevel ("LevelSelectorScene");
	}
}
