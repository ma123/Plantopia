using UnityEngine;
using System.Collections;

public class SoldierScript : MonoBehaviour {
	private Transform secondPoint;
	private int secondId; 
	private float speed = 2.0f;

	void Start () {
		//Destroy (gameObject, 4f);
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

			if(secondId == id) {
				print ("trigger enter destroy");
				switch(typeOfPlayer) {
				case 1: 
					col.gameObject.GetComponentInParent<Buildings>().AddSoldier();
					break;
				case 2: 
					col.gameObject.GetComponentInParent<Buildings>().RemoveSoldier();
					break;
				case 3: 
					col.gameObject.GetComponentInParent<Buildings>().RemoveSoldier();
					break;
				case 4: 
					break;
				}

				Destroy (gameObject);
			}
		}
	}
}
