using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

public class PlayerControllerScript : MonoBehaviour {
	private Transform pointFirst;
	private Transform pointSecond;
	private GameObject selectedObject = null;
	private int firstId = 0;
	private int secondId = 0;
	private GameObject pathObject;
	private Color markColor;
	private Color whiteColor;

	// Use this for initialization
	void Start () {
		pointFirst = GetComponent<Transform> ();
		pointSecond = GetComponent<Transform> ();
		pointFirst = pointSecond = null;
		pathObject = GameObject.Find ("Path");
		markColor = new Color (0.777f, 0.8f, 0.604f);
		markColor.a = 0.4f;
		whiteColor = Color.white;
		whiteColor.a = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) { // ziskam prvu suradnicu , nasledne sa nacitaju vsetky dostupne uzly podla pozicie ydvihnutia kliku sa urci na ktoru stranu sa vzdat
			ClickMousePlayer();
			print ("Click down");
				try {
					if(selectedObject.tag == "BuildingsTouchArea") {
						if(selectedObject.GetComponent<BuildingsScript>().GetTypeOfPlayer() == 1) {  // prva suradnica sa uklada iba ked je budova hracova
							pointFirst = selectedObject.transform;
							pointFirst.GetComponent<SpriteRenderer>().color = markColor; // vyfarbenie prveho bodu kurzor 
							firstId = pointFirst.GetComponent<BuildingsScript>().GetBuildingsId();
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
								pointSecond.GetComponent<SpriteRenderer>().color = markColor;
							} else {
								if(selectedObject.GetComponent<BuildingsScript>().GetTypeOfPlayer() == 1) {
									pointSecond = pointFirst;
									pointSecond.GetComponent<SpriteRenderer>().color = markColor;
								}
							}
						}
					}
				} catch {
					Debug.Log("hit collider game object == null");
				}
		}



		if ((pointFirst == pointSecond) && (pointFirst != null) && (pointSecond != null)) {
			StartCoroutine(WaitMoment(pointFirst, pointSecond));
			pointFirst = pointSecond = null;
			selectedObject = null;
		} else {
			if((pointFirst != null) && (pointSecond != null)) {
				SettingSender();
				StartCoroutine(WaitMoment(pointFirst, pointSecond));
				pointFirst = pointSecond = null;
				selectedObject = null;
			}

		}
	}

	IEnumerator WaitMoment(Transform first, Transform second) {
		yield return new WaitForSeconds(0.5f);
		first.GetComponent<SpriteRenderer>().color = whiteColor;
		second.GetComponent<SpriteRenderer>().color = whiteColor;
	}

	private void SettingSender() {
		this.GetComponent<PlayeSoldierSenderScript>().SetZeroLock(true);
		this.GetComponent<PlayeSoldierSenderScript>().SetFirstPoint(pointFirst);
		this.GetComponent<PlayeSoldierSenderScript>().SetSecondPoint(pointSecond);
		this.GetComponent<PlayeSoldierSenderScript>().SetSecondId(secondId);
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
