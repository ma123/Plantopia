using UnityEngine;
using System.Collections;

public class PanelManagerScript : MonoBehaviour {
	public GameObject[] panels;
	private int currentPanelIndex;

	void Start () {
		currentPanelIndex = 0;
		//PlayerPrefs.DeleteAll ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			ChangePanel(1);
		}
	}

	public void ChangePanel(int panelIndex) {
		panels [currentPanelIndex].SetActive (false);
		currentPanelIndex = panelIndex;
		panels [currentPanelIndex].SetActive (true);
	}

}
