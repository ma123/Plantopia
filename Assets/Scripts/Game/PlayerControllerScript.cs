using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControllerScript : MonoBehaviour {
	private Transform pointFirst;
	private Transform pointSecond;
	private GameObject firstPointObject;
	private GameObject selectedObject = null;
	private int firstId = 0;
	private int secondId = 0;
	private GameObject pathObject;

	// Use this for initialization
	void Start () {
		pointFirst = GetComponent<Transform> ();
		pointSecond = GetComponent<Transform> ();
		pointFirst = pointSecond = null;
		pathObject = GameObject.Find ("Path");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			ClickMousePlayer();
			print ("Click down");
				try {
					if(selectedObject.tag == "BuildingsTouchArea") {
						firstPointObject = selectedObject;
						if(firstPointObject.GetComponent<BuildingsScript>().GetTypeOfPlayer() == 1) {  // prva suradnica sa uklada iba ked je budova hracova
							pointFirst = firstPointObject.transform;
							firstId = firstPointObject.GetComponent<BuildingsScript>().GetBuildingsId();
						}
					}
				} catch {
					Debug.Log("hit collider game object == null");
				}
		}

		if(Input.GetMouseButtonUp(0)) {
			ClickMousePlayer();
			print ("Click up");
				try {
					if(selectedObject.tag == "BuildingsTouchArea") {
						if(pointFirst != null) { // druha suradnica sa uklada iba ak prva suradnina nie je null
							List<bool> pathList = pathObject.GetComponent<PathScript>().GetPath(firstId); // list kde su ulozene cesty kadial moze byt vzslana armada
							secondId = selectedObject.GetComponent<BuildingsScript>().GetBuildingsId(); // ziskanie id druhej budovy
							if(pathList[secondId] == true) { // ak je cesta true tak ulozi suradnicu
								pointSecond = selectedObject.transform;
							}
						}
					}
				} catch {
					Debug.Log("hit collider game object == null");
				}
		}

		if ((pointFirst == pointSecond) && (pointFirst != null) && (pointSecond != null)) {
			print ("Su body su rovnake");
			pointFirst = pointSecond = null;
			// todo upgrade budov
			return;
		} else {
			if((pointFirst != null) && (pointSecond != null)) {
				this.GetComponent<SendSoldierScript>().SetZeroLock(true);
				this.GetComponent<SendSoldierScript>().SetFirstPoint(pointFirst);
				this.GetComponent<SendSoldierScript>().SetSecondPoint(pointSecond);
				this.GetComponent<SendSoldierScript>().SetSecondId(secondId);
				pointFirst = pointSecond = null;
			}
		}
	}

	private void ClickMousePlayer() {
		Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D[] hits = Physics2D.LinecastAll(clickPosition, clickPosition);
		
		if(hits.Length != 0) {
			selectedObject = hits[0].collider.gameObject;
			for(int i = 1; i < hits.Length; i++) {
				try {
					if(hits[i].collider.gameObject.GetComponent<Renderer>().sortingOrder >= selectedObject.GetComponent<Renderer>().sortingOrder) {
						selectedObject = hits[i].collider.gameObject;
					}
				} catch {
					Debug.Log("there is no renderer soldier clone");
				}
			}
		}
	}

	public Transform GetPointFirst() {
		return pointFirst;
	}
	
	public Transform GetPointSecond() {
		return pointSecond;
	}
}
