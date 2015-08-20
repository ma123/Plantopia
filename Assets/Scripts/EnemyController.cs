using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {
	private int enemyType = 3; // 3cerveny 4 oranzovy 5 fialovy ...
	private GameObject[] buildingsList;
	private GameObject pathObject;

	public Rigidbody2D rigidBody;
	Rigidbody2D bulletInstance = null;
	private Transform pointFirst;
	private Transform pointSecond;
    private int firstId = 0;
	private int secondId = 0;
	private float waitEnemyTime = 2f;
	private float lastTime = 0f;

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
		for(int i = 0; i < buildingsList.Length; i++) {
			if((buildingsList[i].GetComponent<BuildingsScript>().GetTypeOfPlayer() == enemyType)) { // popripade iny hraci
				pointFirst = buildingsList[i].transform;
			}
			if((buildingsList[i].GetComponent<BuildingsScript>().GetTypeOfPlayer() == 1)) { // popripade iny hraci
				pointSecond = buildingsList[i].transform;
			}
		}

		if((pointFirst != null) && (pointSecond != null)) {
			BulletMove();
		}

		/*List<bool> pathList = pathObject.GetComponent<PathScript>().GetPath(firstId); // list kde su ulozene cesty kadial moze byt vzslana armada
		secondId = selectedObject.GetComponent<BuildingsScript>().GetBuildingsId(); // ziskanie id druhej budovy
		if(pathList[secondId] == true) { // ak je cesta true tak ulozi suradnicu
			pointSecond = selectedObject.transform;
		}*/
	}

	private void BulletMove() {
		bulletInstance = Instantiate (rigidBody, pointFirst.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
		bulletInstance.GetComponent<EnemySoldierScript> ().SetSecondPoint (pointSecond);
		bulletInstance.GetComponent<EnemySoldierScript> ().SetSecondId (secondId);
	}
}
