using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Transform pointFirst;
	private Transform pointSecond;
	private GameObject firstPointObject;
	public Rigidbody2D rigidBody;
	Rigidbody2D bulletInstance = null;
	private float waitTime = 1f;
	private int secondId = 0;
	private bool waitLock = false;

	//public GameObject gameObject;


	// Use this for initialization
	void Start () {
		pointFirst = GetComponent<Transform> ();
		pointSecond = GetComponent<Transform> ();
		pointFirst = pointSecond = null;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D[] hits = Physics2D.LinecastAll(clickPosition, clickPosition);

			GameObject selectedObject = null;

			if(hits.Length != 0) {
				selectedObject = hits[0].collider.gameObject;
				print (selectedObject);
				for(int i = 1; i < hits.Length; i++) {
					if(hits[i].collider.gameObject.GetComponent<Renderer>().sortingOrder >= selectedObject.GetComponent<Renderer>().sortingOrder) {
						selectedObject = hits[i].collider.gameObject;
					}
				}

				try {
					if(selectedObject.tag == "BuildingsTouchArea") {
						firstPointObject = selectedObject;
						if(firstPointObject.GetComponent<Buildings>().GetTypeOfPlayer() == 1) {  // prva suradnica sa uklada iba ked je budova hracova
							pointFirst = firstPointObject.transform;
						}
					}
				} catch {
					Debug.Log("hit collider game object == null");
				}
			}

			/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			try {
				if(hit.collider.gameObject.tag == "BuildingsTouchArea") {
					firstPointObject = hit.collider.gameObject;
					if(firstPointObject.GetComponent<Buildings>().GetTypeOfPlayer() == 1) {  // prva suradnica sa uklada iba ked je budova hracova
						pointFirst = firstPointObject.transform;
					}
				}
			} catch {
				Debug.Log("hit collider game object == null");
			}*/
		}

		if(Input.GetMouseButtonUp(0)) {
			Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D[] hits = Physics2D.LinecastAll(clickPosition, clickPosition);
			
			GameObject selectedObject = null;
			
			if(hits.Length != 0) {
				selectedObject = hits[0].collider.gameObject;
				for(int i = 1; i < hits.Length; i++) {
					if(hits[i].collider.gameObject.GetComponent<Renderer>().sortingOrder >= selectedObject.GetComponent<Renderer>().sortingOrder) {
						selectedObject = hits[i].collider.gameObject;
					}
				}

				try {
					if(selectedObject.tag == "BuildingsTouchArea") {
						if(pointFirst != null) { // druha suradnica sa uklada iba ak prva suradnina nie je null
							pointSecond = selectedObject.transform;
							secondId = selectedObject.GetComponent<Buildings>().GetBuildingsId();
						}
					}
				} catch {
					Debug.Log("hit collider game object == null");
				}
			}


			/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			try {
				if(hit.collider.gameObject.tag == "BuildingsTouchArea") {
					if(pointFirst != null) { // druha suradnica sa uklada iba ak prva suradnina nie je null
						pointSecond = hit.collider.gameObject.transform;
						secondId = hit.collider.gameObject.GetComponent<Buildings>().buildingId;
					}
				}
			} catch {
				Debug.Log("hit collider game object == null");
			}*/
		}

		if (pointFirst == pointSecond) {
			pointFirst = pointSecond = null;
			// todo upgrade budov
			return;
		} else {
			if((pointFirst != null) && (pointSecond != null)) {
				for(int i = 0; i < 5; i++) {
					StartCoroutine(WaitTime());
						BulletMove ();
				}
					
				//firstPointObject.GetComponent<Buildings>().RemoveSoldier();
				pointFirst = pointSecond = null;
			}
		}
	}

	IEnumerator WaitTime() {
		print(Time.time);
		yield return new WaitForSeconds(1);
		print(Time.time);
	}
	
	private void BulletMove() {
		bulletInstance = Instantiate (rigidBody, pointFirst.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
		bulletInstance.GetComponent<SoldierScript> ().SetSecondPoint (pointSecond);
	    bulletInstance.GetComponent<SoldierScript> ().SetSecondId (secondId);
	}

	public Transform GetPointFirst() {
		return pointFirst;
	}
	
	public Transform GetPointSecond() {
		return pointSecond;
	}
}
