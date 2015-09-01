using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckWinnerScript : MonoBehaviour {
	private GameObject[] buildingsList; 
	private bool winner = false;
	private bool loser = false;
	private int enemy = 0;
	private int player = 0;
	public GameObject winPanel;
	public GameObject lossPanel;

	void Start () {
		buildingsList = GameObject.FindGameObjectsWithTag ("BuildingsTouchArea");
	}

	void Update () {
		for(int i = 0; i < buildingsList.Length; i++) {
			if((buildingsList[i].GetComponent<BuildingsScript>().GetTypeOfPlayer() == 3) || (buildingsList[i].GetComponent<BuildingsScript>().GetTypeOfPlayer() == 4)) { // popripade iny hraci
				enemy++;
			} else {
				if(buildingsList[i].GetComponent<BuildingsScript>().GetTypeOfPlayer() == 1) { // popripade iny hraci
					player++;
				}
			}
		}

		if(enemy == 0) {
			winner = true;
		}

		if(player == 0) {
			loser = true;
		}
		enemy = player = 0;
	}

	void OnGUI() {
		if (winner) {
			Time.timeScale = 0; // pauznutie hry
			winPanel.SetActive(true);
			winner = false;
		} 
		if (loser) {
			Time.timeScale = 0; // pauznutie hry
			lossPanel.SetActive(true);
			loser = false;
		} 
	}
}
