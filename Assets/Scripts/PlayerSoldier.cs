using UnityEngine;
using System.Collections;

public class PlayerSoldier : MonoBehaviour {
	private Transform secondPoint;
	private int secondId; 
	private float speed = 2.0f;

	void Start () {
		//Destroy (gameObject, 10f);
	}

	void Update() {
		transform.position = Vector2.MoveTowards(transform.position, secondPoint.position, Time.deltaTime* speed); // time deltatime mozny problem pri roydielnych zariadeniach
	}

	public void SetSecondPoint(Transform secondPoint) {
		this.secondPoint = secondPoint;
	}

	public void SetSecondId(int secondId) {
		this.secondId = secondId;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Buildings") {
			int id = col.gameObject.GetComponentInParent<Buildings>().GetBuildingsId();
			int typeOfPlayer = col.gameObject.GetComponentInParent<Buildings>().GetTypeOfPlayer();
			int numberOfSoldier = col.gameObject.GetComponentInParent<Buildings>().GetNumberOfSoldier();
			GameObject buildings = col.gameObject;

			if(secondId == id) {
				print ("trigger enter destroy");
				switch(typeOfPlayer) {
				case 1: 
					buildings.GetComponentInParent<Buildings>().AddSoldier();
					break;
				case 2: // neutral
					if(numberOfSoldier > 0) {
						buildings.GetComponentInParent<Buildings>().RemoveSoldier();
					} else {
						buildings.GetComponentInParent<Buildings>().SetTypeOfPlayer(1);
						buildings.GetComponentInParent<Buildings>().AddSoldier();
					}

					break;
				case 3: // enemy
					if(numberOfSoldier > 0) {
						buildings.GetComponentInParent<Buildings>().RemoveSoldier();
					} else {
						buildings.GetComponentInParent<Buildings>().SetTypeOfPlayer(1);
						buildings.GetComponentInParent<Buildings>().AddSoldier();
					}
					break;
				case 4: 
					break;
				}

				Destroy (gameObject);
			}
		}
	}
}
