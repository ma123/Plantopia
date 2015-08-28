using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyControllerScript : MonoBehaviour {
	public int enemyType = 0; // 3cerveny 4 fialovy
	private GameObject[] buildingsList;
	private GameObject pathObject;

	public Rigidbody2D rigidBody;
	private Rigidbody2D bulletInstance = null;
	private GameObject firstObject;
	private GameObject secondObject;
	private Transform pointFirst;
	private Transform pointSecond;
    private int firstId = 0;
	private int secondId = 0;
	private float waitEnemyTime = 1f;
	private float lastTime = 0f;
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
		if(Time.time > waitEnemyTime + lastTime) {
			List<int> listEnemyBuildings = new List<int>();

			for(int i = 0; i < buildingsList.Length; i++) {
				if((buildingsList[i].GetComponent<BuildingsScript>().GetTypeOfPlayer() == enemyType)) { // popripade iny hraci
					listEnemyBuildings.Add(buildingsList[i].GetComponent<BuildingsScript>().GetBuildingsId());
				}
			}
		
			if(destinationLock) {
				if(listEnemyBuildings.Count > 0) {
					selectedNode = listEnemyBuildings[Random.Range(0,listEnemyBuildings.Count)];
				} else {
					return;
				}
			}

			for(int i = 0; i < buildingsList.Length; i++) {
				if((buildingsList[i].GetComponent<BuildingsScript>().GetBuildingsId() == selectedNode)) {
					firstObject = buildingsList[i];
					pointFirst = buildingsList[i].transform;
				}
			}
			
			List<bool> pathList = pathObject.GetComponent<PathScript>().GetPath(selectedNode);

			if(destinationLock) {
				while(true) {
					int randomNumber = Random.Range(0,(pathList.Count));
					if(pathList[randomNumber]) {
						buildIndex = randomNumber;
						destinationLock = false;
						break;
					}
				}
			}

			for(int i = 0; i < buildingsList.Length; i++) {
				if((buildingsList[i].GetComponent<BuildingsScript>().GetBuildingsId() == buildIndex)) { // popripade iny hraci
					secondObject = buildingsList[i];
					secondId = secondObject.GetComponent<BuildingsScript>().GetBuildingsId(); // ziskanie id druhej budovy
					pointSecond = buildingsList[i].transform;
				}
			}

			if((pointFirst != null) && (pointSecond != null)) {
				if(secondObject.GetComponent<BuildingsScript>().GetTypeOfPlayer() == enemyType) {// problem ked sa tento uzol dobije nepriatel sa stale snazi z neho utocit napriek tomu ze patri inemu hracovi uz
					destinationLock = true;
				} else {
					if(firstObject.GetComponent<BuildingsScript>().GetTypeOfPlayer() != enemyType) {
						destinationLock = true;
					}
				}
				if(firstObject.GetComponent<BuildingsScript>().GetNumberOfSoldier() > 0) {
					BulletMove();
					firstObject.GetComponent<BuildingsScript>().RemoveSoldier();

					pointFirst = pointSecond = null;
				}
			}

			lastTime = Time.time;
		}
	}

	private void BulletMove() {
		try{
			switch(enemyType) {
			case 3:
				bulletInstance = Instantiate (rigidBody, pointFirst.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.GetComponent<EnemySoldierRedScript> ().SetSecondPoint (pointSecond);
				bulletInstance.GetComponent<EnemySoldierRedScript> ().SetSecondId (secondId);
				break;
			case 4:
				bulletInstance = Instantiate (rigidBody, pointFirst.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.GetComponent<EnemySoldierVioletScript> ().SetSecondPoint (pointSecond);
				bulletInstance.GetComponent<EnemySoldierVioletScript> ().SetSecondId (secondId);
				break;
			}		
		} catch{
			Debug.Log("bullet not shoot");
		};
	}
}
