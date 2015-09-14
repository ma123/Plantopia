using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyControllerScript : MonoBehaviour {
	public int enemyType = 0; // 3cerveny 4 fialovy
	private GameObject[] buildingsList;
	private GameObject pathObject;

	private Transform pointFirst;
	private Transform pointSecond;
	private int secondId = 0;
	private int buildIndex = 0;
	private int selectedNode = 0;
	private bool destinationLock = true;

	// Use this for initialization
	void Start () {
		pointFirst = GetComponent<Transform> ();
		pointSecond = GetComponent<Transform> ();
		pointFirst = pointSecond = null;
		buildingsList = GameObject.FindGameObjectsWithTag ("BuildingsTouchArea");
		pathObject = GameObject.Find ("Path");
	}
	
	// Update is called once per frame
	void Update () {
			List<int> listEnemyBuildings = new List<int>(); // inicializacia listu nepriatelskych budov

			for(int i = 0; i < buildingsList.Length; i++) {
				if((buildingsList[i].GetComponent<BuildingsScript>().GetTypeOfPlayer() == enemyType)) { // najdem vsetkych nepriatelov jedneho typu napr cerveny
					listEnemyBuildings.Add(buildingsList[i].GetComponent<BuildingsScript>().GetBuildingsId()); // pridanie id budovy do listu
				}
			}
		
			if(destinationLock) { // zamok na utocenie na urcitu budovu
				if(listEnemyBuildings.Count > 0) { 
					selectedNode = listEnemyBuildings[Random.Range(0,listEnemyBuildings.Count)]; // vyberie nahodne jednu z budov nepriatela
				} else {
					return;
				}
			}

			for(int i = 0; i < buildingsList.Length; i++) {
				if((buildingsList[i].GetComponent<BuildingsScript>().GetBuildingsId() == selectedNode)) {
					pointFirst = buildingsList[i].transform; // vyber prveho bodu z ktoreho sa bdue utocit
				}
			}
			
			List<bool> pathList = pathObject.GetComponent<PathScript>().GetPath(selectedNode); // list ciest podla vybraneho uzlu z ktoreho utocime

			if(destinationLock) { 
				while(true) {
					int randomNumber = Random.Range(0,(pathList.Count)); // nahodny vyber cesty ku uzlu
					if(pathList[randomNumber]) {
						buildIndex = randomNumber;
						destinationLock = false;
						break;
					}
				}
			}

			for(int i = 0; i < buildingsList.Length; i++) {
				if((buildingsList[i].GetComponent<BuildingsScript>().GetBuildingsId() == buildIndex)) { // popripade iny hraci
					pointSecond = buildingsList[i].transform; // ziskanie druhej suradnice
					secondId = pointSecond.GetComponent<BuildingsScript>().GetBuildingsId(); // ziskanie id druhej budovy
				}
			}

			if((pointFirst != null) && (pointSecond != null)) {
				if(pointSecond.GetComponent<BuildingsScript>().GetTypeOfPlayer() == enemyType) {
					destinationLock = true;
				} else {
					if(pointFirst.GetComponent<BuildingsScript>().GetTypeOfPlayer() != enemyType) {
						destinationLock = true;
					}
				}

				if(pointFirst.GetComponent<BuildingsScript>().GetNumberOfSoldier() > 1) {
					SettingEnemySender();
					pointFirst = pointSecond = null;
				} else {
					destinationLock = true;
				}
			}
	}

	private void SettingEnemySender() {
		this.GetComponent<EnemySoldierSenderScript>().SetZeroLock(true);
		this.GetComponent<EnemySoldierSenderScript>().SetFirstPoint(pointFirst);
		this.GetComponent<EnemySoldierSenderScript>().SetSecondPoint(pointSecond);
		this.GetComponent<EnemySoldierSenderScript>().SetSecondId(secondId);
	}
}
