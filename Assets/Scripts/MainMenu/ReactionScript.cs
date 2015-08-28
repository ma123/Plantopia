using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReactionScript : MonoBehaviour {
	public void ClickedLevelSelector() {
		print ("clicked load LevelSelector");
		Application.LoadLevel ("LevelSelectorScene");
	}

	public void ClickedExit() {
		print ("clicked exit");
		Application.Quit ();
	}
}
