using UnityEngine;
using System.Collections;

public class PlayerSoldierScript : MonoBehaviour {
	private Transform secondPoint;
	private int secondId; 
	private float speed = 1f;

	void Start () {
		Destroy (gameObject, 10f);
	}

	void Update() {
		try {
			transform.position = Vector2.MoveTowards(transform.position, secondPoint.position, Time.deltaTime* speed); // time deltatime mozny problem pri roydielnych zariadeniach
		} catch {
			Debug.Log("player soldier problem");
		}
	}

	public void SetSecondPoint(Transform secondPoint) {
		this.secondPoint = secondPoint;
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
