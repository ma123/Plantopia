using UnityEngine;
using System.Collections;

public class PlayerSoldierScript : MonoBehaviour {
	private Transform firstPoint;
	private Transform secondPoint;
	private int secondId; 
	public float speed = 1f;
	private float waitTime = 0f;
	private bool stopLock = true;
	private bool waitLock = false;

	void Start () {
		Destroy (gameObject, 30f);
	}

	void Update() {
		try {
			if(stopLock) {
				stopLock = false;
				StartCoroutine (WaitMoment());
			}

			if(waitLock) {
				transform.position = Vector2.MoveTowards(transform.position, secondPoint.position, Time.deltaTime* speed); // time deltatime mozny problem pri roydielnych zariadeniach
			}
		} catch {
			Debug.Log("player soldier problem");
		}
	}

	public IEnumerator WaitMoment() {
		yield return new WaitForSeconds (waitTime);
		waitLock = true;
		/*if(firstPoint.GetComponent<BuildingsScript>().GetNumberOfSoldier() > 0) {
			firstPoint.GetComponent<BuildingsScript>().RemoveSoldier();
		}*/
	}

	public void SetFirstPoint(Transform firstPoint) {
		this.firstPoint = firstPoint;
	}

	public void SetSecondPoint(Transform secondPoint) {
		this.secondPoint = secondPoint;
	}

	public void SetWaitTime(float waitTime) {
		this.waitTime = waitTime;
	}
	
	public void SetSecondId(int secondId) {
		this.secondId = secondId;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Buildings") {
			int id = col.gameObject.GetComponentInParent<BuildingsScript>().GetBuildingsId();
			int typeOfPlayer = col.gameObject.GetComponentInParent<BuildingsScript>().GetTypeOfPlayer();
			int numberOfSoldier = col.gameObject.GetComponentInParent<BuildingsScript>().GetNumberOfSoldier();
			GameObject buildings = col.gameObject;

			if(secondId == id) {
				switch(typeOfPlayer) {
				case 1: 
					buildings.GetComponentInParent<BuildingsScript>().AddSoldier();
					break;
				case 2: // neutral
					if(numberOfSoldier > 0) {
						buildings.GetComponentInParent<BuildingsScript>().RemoveSoldier();
					} else {
						buildings.GetComponentInParent<BuildingsScript>().SetTypeOfPlayer(1);
						buildings.GetComponentInParent<BuildingsScript>().AddSoldier();
					}

					break;
				case 3: // enemy red
					if(numberOfSoldier > 0) {
						buildings.GetComponentInParent<BuildingsScript>().RemoveSoldier();
					} else {
						buildings.GetComponentInParent<BuildingsScript>().SetTypeOfPlayer(1);
						buildings.GetComponentInParent<BuildingsScript>().AddSoldier();
					}
					break;
				case 4: // enemy violet
					if(numberOfSoldier > 0) {
						buildings.GetComponentInParent<BuildingsScript>().RemoveSoldier();
					} else {
						buildings.GetComponentInParent<BuildingsScript>().SetTypeOfPlayer(1);
						buildings.GetComponentInParent<BuildingsScript>().AddSoldier();
					}
					break;
				}

				Destroy (gameObject);
			}
		} else {  	
			if(col.tag == "EnemySoldierRed") {
				//if(Random.Range(0, 2) == 1) {
					Destroy (gameObject);
				//} else {
					Destroy (col.gameObject);
				//}
			}

			if(col.tag == "EnemySoldierViolet") {
				//if(Random.Range(0, 2) == 1) {
				Destroy (gameObject);
				//} else {
				Destroy (col.gameObject);
				//}
			}
		}
	}
}
