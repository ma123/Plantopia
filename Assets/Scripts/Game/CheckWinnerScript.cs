using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckWinnerScript : MonoBehaviour {
	private GameObject[] buildingsList; 
	private bool winner = false;

	// Use this for initialization
	void Start () {
		buildingsList = GameObject.FindGameObjectsWithTag ("BuildingsTouchArea");
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < buildingsList.Length; i++) {
			if((buildingsList[i].GetComponent<BuildingsScript>().GetTypeOfPlayer() == 3) || (buildingsList[i].GetComponent<BuildingsScript>().GetTypeOfPlayer() == 4)) { // popripade iny hraci
				winner = false;
				return;
			} else {
				winner = true;
			}
		}

		if(winner) {
			print ("Vyhral si");
		}
	}
}
